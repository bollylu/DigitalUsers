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
    RetVal.AppendLine($"  subgraph {departmentId}");
    IPerson? HeadOfDepartment = _DataSource.GetHeadOfDepartment(departmentId);
    if (HeadOfDepartment is null) {
      throw new ApplicationException("Error in data hierachy");
    }
    if (_DataSource.GetDepartmentMembers(departmentId).Count() == 1) {
      RetVal.AppendLine($"    {HeadOfDepartment.Id}");
    } else {
      foreach (IPerson PersonItem in _DataSource.GetDepartmentMembers(departmentId)) {
        if (PersonItem.Id != HeadOfDepartment.Id) {
          RetVal.AppendLine($"    {HeadOfDepartment.Id} ==> {PersonItem.Id}");
        }
      }
    }
    RetVal.AppendLine($"  end");
    return RetVal.ToString();
  }

  public string BuildSubDepartments(string department) {
    IEnumerable<IPerson> DepartmentMembers = _DataSource.GetDepartmentMembers(department);
    if (DepartmentMembers.IsEmpty()) {
      return "";
    }
    IEnumerable<IDepartment> SubDepartments = _DataSource.GetSubDepartments(department);
    if (SubDepartments.IsEmpty()) {
      return string.Empty;
    }

    StringBuilder RetVal = new();
    foreach (IDepartment SubDepartmentItem in SubDepartments) {
      RetVal.AppendLine($"  subgraph {department}/{SubDepartmentItem.Id}");
      foreach (IPerson PersonItem in _DataSource.GetDepartmentMembers(department).Where(x => x.SubDepartment == SubDepartmentItem)) {
        RetVal.AppendLine($"    {PersonItem.Id}");
      }
      RetVal.AppendLine($"  end");
      RetVal.AppendLine();
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
      foreach (IDepartment SubDepartmentItem in _DataSource.GetSubDepartments(DepartmentItem.Id)) {
        RetVal.AppendIndent(BuildSubDepartments(DepartmentItem.Id));
        RetVal.AppendLine();
      }
    }



    foreach (IDepartment DepartmentItem in _DataSource.GetDepartments().Where(x => x.Id.Trim() != "Direction")) {
      RetVal.AppendIndent($"Direction --> {DepartmentItem.Id}");
      RetVal.AppendLine();
    }

    return RetVal.ToString();
  }
}
