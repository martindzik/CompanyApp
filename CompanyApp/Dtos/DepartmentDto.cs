using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DepartmentDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
