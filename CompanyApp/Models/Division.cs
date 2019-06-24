using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Models
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int ManagerId { get; set; }

        public Division(int id, string name, int companyId, int managerId)
        {
            Id = id;
            Name = name;
            CompanyId = companyId;
            ManagerId = managerId;
        }
    }
}
