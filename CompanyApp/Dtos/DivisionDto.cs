using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Dtos
{
    public class DivisionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DivisionDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
