using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLTools;

namespace digiuserslib;
public class TMermaidConverter {

  private readonly IDataSource _DataSource;

  public TMermaidConverter(IDataSource dataSource) {
    _DataSource = dataSource;
  }

  public string BuildUser(string id) {
    StringBuilder RetVal = new();
    IPerson? Person = _DataSource.GetPerson(id) ?? throw new ApplicationException($"Unknown person {id}");
    RetVal.Append($"  {Person.Id}[");
    RetVal.AppendLine(Person.Name.FullName.WithQuotes());
    RetVal.Append($"  **{Person.Title}**");
    RetVal.AppendLine("]");
    return RetVal.ToString();
  }

  public string BuildDepartment(string departmentId) {
    StringBuilder RetVal = new();

    // Name of the department
    RetVal.AppendLine($"  subgraph {departmentId}");
    IPerson? HeadOfDepartment = _DataSource.GetHeadOfDepartment(departmentId);

    IEnumerable<IPerson> AllDepartmentMembers = _DataSource.GetDepartmentMembers(departmentId);

    if (HeadOfDepartment is not null) {
      // at least one and only one head
      RetVal.AppendLine($"    {HeadOfDepartment.Id}");
      RetVal.AppendLine();

      IEnumerable<string> SubDepartments = AllDepartmentMembers
      .Where(x => x.Id != (HeadOfDepartment?.Id ?? ""))
      .Select(x => x.SubDepartment.Id).Distinct();

      //foreach (string SubDepartmentItem in SubDepartments) {
      //  if (HeadOfDepartment is not null) {
      //    RetVal.AppendLine($"    {HeadOfDepartment.Id} --> {SubDepartmentItem}");
      //  }
      //}

      RetVal.AppendIndent(BuildSubDepartments(departmentId));
      RetVal.AppendLine();

    } else {
      // No head or several heads
      RetVal.AppendLine("    direction LR");
      foreach (string PersonsItem in GetPermutations(AllDepartmentMembers.Select(x => x.Id))) {
        RetVal.AppendLine($"    {PersonsItem}");
      }
    }

    

    RetVal.AppendLine($"  end");
    return RetVal.ToString();
  }

  private static IEnumerable<string> GetPermutations(IEnumerable<string> items) {
    if (items.IsEmpty()) {
      yield return string.Empty;
      yield break;
    }

    if (items.Count() == 1) {
      yield return items.First();
      yield break;
    }

    foreach (string item in items) {
      IEnumerable<string> remaining = items.Where(i => !EqualityComparer<string>.Default.Equals(i, item));
      foreach (string permutation in GetPermutations(remaining)) {
        yield return $"{item} --> {permutation}";
      }
    }
  }


  public string BuildSubDepartments(string departmentId) {
    IPerson? HeadOfDepartment = _DataSource.GetHeadOfDepartment(departmentId);

    //if (HeadOfDepartment is null) {
    //  throw new ApplicationException("Error in data hierachy");
    //}

    IEnumerable<IPerson> DepartmentMembers = _DataSource.GetDepartmentMembers(departmentId);
    if (DepartmentMembers.IsEmpty()) {
      return string.Empty;
    }

    IEnumerable<IDepartment> SubDepartments = _DataSource.GetSubDepartments(departmentId).Distinct();
    if (SubDepartments.IsEmpty()) {
      return string.Empty;
    }

    StringBuilder RetVal = new();
    foreach (IDepartment SubDepartmentItem in SubDepartments.Where(x => x.Name != "")) {
      RetVal.AppendLine($"  subgraph {SubDepartmentItem.Id}");
      foreach (IPerson PersonItem in _DataSource.GetDepartmentMembers(departmentId).Where(x => x.SubDepartment == SubDepartmentItem)) {
        RetVal.AppendLine($"    {PersonItem.Id}");
      }
      RetVal.AppendLine($"  end");
      RetVal.AppendLine();
      if (HeadOfDepartment is not null) {
        RetVal.AppendLine($"  {HeadOfDepartment.Id} --> {SubDepartmentItem.Id}");
        RetVal.AppendLine();
      }
    }

    return RetVal.ToString();
  }

  public string BuildOrganigram() {
    StringBuilder RetVal = new();
    RetVal.AppendLine("flowchart TD");
    RetVal.AppendLine();

    foreach (IPerson PersonItem in _DataSource.GetPeople()) {
      RetVal.AppendIndent(BuildUser(PersonItem.Id));
      RetVal.AppendLine();
    }

    foreach (IDepartment DepartmentItem in _DataSource.GetDepartments()) {
      RetVal.AppendIndent(BuildDepartment(DepartmentItem.Id));
      RetVal.AppendLine();
    }

    return RetVal.ToString();
  }
}
