using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProjectDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
