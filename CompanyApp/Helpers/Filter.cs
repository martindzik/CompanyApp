using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Helpers
{
    public class Filter
    {
        public string SelectedCompany { get; set; } = null;
        public string SelectedDivision { get; set; } = null;
        public string SelectedProject { get; set; } = null;
        public string SelectedDepartment { get; set; } = null;

        public Filter(string selectedCompany, string selectedDivision, string selectedProject, string selectedDepartment)
        {
            SelectedCompany = selectedCompany;
            SelectedDivision = selectedDivision;
            SelectedProject = selectedProject;
            SelectedDepartment = selectedDepartment;
        }
    }
}
