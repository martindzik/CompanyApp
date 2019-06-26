﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EmployeeDto(int id, string name, string surname)
        {
            Id = id;
            Name = name + " " + surname;
        }
    }
}
