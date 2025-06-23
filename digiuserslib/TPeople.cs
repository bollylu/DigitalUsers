using digiuserslib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digiuserslib {
  public class TPeople : List<IPerson>, IPeople {
    public string ConvertToMermaid() {
      return BuildTree(this);
    }

    public string BuildTree(List<IPerson> people) {
      StringBuilder RetVal = new();
      RetVal.AppendLine("flowchart TD");
      foreach (IPerson PersonItem in people) {
        RetVal.AppendLine(BuildUser(PersonItem));
      }
      // Scan all departments
      foreach (string DepartmentItem in people.Select(p => p.Department).Distinct()) {
        // DepartmentMembers
        IEnumerable<IPerson> Members = people.Where(p => p.Department == DepartmentItem);
        // Find the head : the one who does not relates to any in the group
        IPerson? HeadOfDepartment = Members.SingleOrDefault(p => p.DependsOn != DepartmentItem);
        if (HeadOfDepartment is null) {
          throw new ApplicationException("Error in data hierachy");
        }
        RetVal.AppendLine($"  subgraph {DepartmentItem}");
        foreach (IPerson MemberItem in Members.Where(p => p.Id != HeadOfDepartment.Id)) {
          RetVal.AppendLine($"    {HeadOfDepartment.Id}==>{MemberItem.Id}");
        }
        RetVal.AppendLine($"  end");
      }

      return RetVal.ToString();
    }

    public string BuildUser(IPerson person) {
      StringBuilder RetVal = new();
      RetVal.AppendLine($"{person.Id}[");
      RetVal.AppendLine(person.Name.FullName);
      RetVal.Append($"**{person.Title}**");
      RetVal.AppendLine("]");
      return RetVal.ToString();
    }

    public IEnumerable<string> GetDepartments() {
      return this.Select(p => p.Department).Distinct();
    }

    public IPerson? GetHeadOfDepartment(string department) {
      return this.Where(p => p.Department == department).SingleOrDefault(p => p.DependsOn != department);
    }
  }
}
