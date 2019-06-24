using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
        public int LeaderId { get; set; }

        public Project(int id, string name, int divisionId, int leaderId)
        {
            Id = id;
            Name = name;
            DivisionId = divisionId;
            LeaderId = leaderId;
        }
    }
}
