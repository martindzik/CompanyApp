using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Models
{
    public class Leader
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }

        public Leader(int id, string title, string name, string surname)
        {
            Id = id;
            Title = title;
            Name = name;
            Surname = surname;
            FullName = Title + ' ' + Name + ' ' + Surname;
        }
    }
}
