﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int LeaderId { get; set; }

        public Department(int id, string name, int projectId, int leaderId)
        {
            Id = id;
            Name = name;
            ProjectId = projectId;
            LeaderId = leaderId;
        }
    }
}
