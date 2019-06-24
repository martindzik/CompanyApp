using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DirectorId { get; set; }

        public Company(int id, string name, int directorId)
        {
            Id = id;
            Name = name;
            DirectorId = directorId;
        }
    }
}
