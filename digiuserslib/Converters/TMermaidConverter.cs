using System.Text;

using BLTools;

namespace digiuserslib;

public class TMermaidConverter {

  private readonly IDataSourceAsync _DataSource;

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TMermaidConverter(IDataSourceAsync dataSource) {
    _DataSource = dataSource;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public string BuildUser(string id) {
    StringBuilder RetVal = new();
    //IPerson? Person = _DataSource.GetPerson(id) ?? throw new ApplicationException($"Unknown person {id}");
    //RetVal.Append($"  {Person.Id}[");
    //RetVal.AppendLine(Person.Name.FullName.WithQuotes());
    //RetVal.Append($"  **{Person.Title}**");
    //RetVal.AppendLine("]");
    return RetVal.ToString();
  }

  public string BuildDepartment(string departmentId) {
    StringBuilder RetVal = new();

    //IEnumerable<IPerson> AllDepartmentMembers = _DataSource.GetDepartmentMembers(departmentId);

    //// case 1: no members
    //if (AllDepartmentMembers.IsEmpty()) {
    //  // Name of the department
    //  RetVal.AppendLine($"  subgraph {departmentId}");
    //  RetVal.AppendLine($"  end");
    //  return RetVal.ToString();
    //}

    //// case 2: only one member
    //if (AllDepartmentMembers.Count() == 1) {
    //  // Name of the department
    //  RetVal.AppendLine($"  subgraph {departmentId}");
    //  RetVal.AppendLine($"    {AllDepartmentMembers.First().Id}");
    //  RetVal.AppendLine($"  end");
    //  return RetVal.ToString();
    //}

    //// case 3: several members
    //RetVal.AppendLine($"  subgraph {departmentId}");
    //IPerson? HeadOfDepartment = _DataSource.GetHeadOfDepartment(departmentId);

    //// Head of department
    //if (HeadOfDepartment is not null) {
    //  RetVal.AppendLine($"    {HeadOfDepartment.Id}");
    //  RetVal.AppendLine();

    //  IEnumerable<IDepartment> SubDepartments = _DataSource.GetSubDepartments(departmentId).Distinct();

    //  // Members of the department not in any subdepartment, but not the head of department
    //  foreach (IPerson PersonItem in AllDepartmentMembers.Where(x => x.Id != HeadOfDepartment.Id).Where(x => x.SubDepartment.Id.IsEmpty())) {
    //    RetVal.AppendLine($"    {HeadOfDepartment.Id} --> {PersonItem.Id}");
    //  }

    //  foreach (IDepartment SubDepartmentItem in SubDepartments) {
    //    RetVal.AppendLine(BuildDepartment(SubDepartmentItem.Id));
    //  }

    //} else {
    //  // No head of department, just list the members
    //  foreach (IPerson PersonItem in AllDepartmentMembers) {
    //    RetVal.AppendLine($"    {PersonItem.Id}");
    //  }
    //}

    ////// Subdepartments
    ////IEnumerable<string> SubDepartmentIds = AllDepartmentMembers
    ////  .Where(x => x.Id != (HeadOfDepartment?.Id ?? ""))
    ////  .Select(x => x.SubDepartment.Id).Distinct();

    ////foreach (string SubDepartmentIdItem in SubDepartmentIds) {
    ////  if (HeadOfDepartment is not null) {
    ////    RetVal.AppendLine($"    {HeadOfDepartment.Id} --> {SubDepartmentIdItem}");
    ////  } else {
    ////    RetVal.AppendLine($"    {SubDepartmentIdItem}");
    ////  }
    ////}

    ////RetVal.AppendIndent(BuildSubDepartments(departmentId));

    //RetVal.AppendLine($"  end");
    return RetVal.ToString();
  }



  //private static IEnumerable<string> GetPermutations(IEnumerable<string> items) {
  //  if (items.IsEmpty()) {
  //    yield return string.Empty;
  //    yield break;
  //  }

  //  if (items.Count() == 1) {
  //    yield return items.First();
  //    yield break;
  //  }

  //  foreach (string item in items) {
  //    IEnumerable<string> remaining = items.Where(i => !EqualityComparer<string>.Default.Equals(i, item));
  //    foreach (string permutation in GetPermutations(remaining)) {
  //      yield return $"{item} --> {permutation}";
  //    }
  //  }
  //}


  public string BuildSubDepartments(string departmentId) {
    StringBuilder RetVal = new();

    //IPerson? HeadOfDepartment = _DataSource.GetHeadOfDepartment(departmentId);

    //if (HeadOfDepartment is null) {
    //  throw new ApplicationException("Error in data hierachy");
    //}

    //IEnumerable<IPerson> DepartmentMembers = _DataSource.GetDepartmentMembers(departmentId);
    //if (DepartmentMembers.IsEmpty()) {
    //  return string.Empty;
    //}

    //IEnumerable<IDepartment> SubDepartments = _DataSource.GetSubDepartments(departmentId).Distinct();
    //if (SubDepartments.IsEmpty()) {
    //  return string.Empty;
    //}

    //foreach (IDepartment SubDepartmentItem in SubDepartments.Where(x => x.Name != "")) {
    //  RetVal.AppendLine($"  subgraph {SubDepartmentItem.Id}");
    //  foreach (IPerson PersonItem in _DataSource.GetDepartmentMembers(departmentId).Where(x => x.SubDepartment == SubDepartmentItem)) {
    //    RetVal.AppendLine($"    {PersonItem.Id}");
    //  }
    //  RetVal.AppendLine($"  end");
    //  RetVal.AppendLine();
    //  //if (HeadOfDepartment is not null) {
    //  //  RetVal.AppendLine($"  {HeadOfDepartment.Id} --> {SubDepartmentItem.Id}");
    //  //  RetVal.AppendLine();
    //  //}
    //}

    return RetVal.ToString();
  }

  public string BuildOrganigram() {
    StringBuilder RetVal = new();
    //RetVal.AppendLine("flowchart TD");
    //RetVal.AppendLine();

    //foreach (IPerson PersonItem in _DataSource.GetPeople()) {
    //  RetVal.AppendIndent(BuildUser(PersonItem.Id));
    //  RetVal.AppendLine();
    //}

    //foreach (IDepartment DepartmentItem in _DataSource.GetDepartments()) {
    //  RetVal.AppendIndent(BuildDepartment(DepartmentItem.Id));
    //  RetVal.AppendLine();
    //}

    return RetVal.ToString();
  }
}
