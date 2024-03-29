﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }

        public Employee() { }

        public Employee(int id, string title, string name, string surname,
            string phoneNumber, string email, string position, int departmentId)
        {
            Id = id;
            Title = title;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Position = position;
            DepartmentId = departmentId;
        }
    }
}
