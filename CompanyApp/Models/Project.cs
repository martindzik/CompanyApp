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
    }
}
