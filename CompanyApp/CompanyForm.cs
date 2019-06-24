using CompanyApp.DbWrapper;
using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyApp
{
    public partial class CompanyForm : Form
    {
        private readonly Database _database = new Database();
        public CompanyForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private void CompanyForm_Shown(object sender, EventArgs e)
        {
            var companies = _database.GetCompanies();

            companiesComboBox.DataSource = companies;
            companiesComboBox.DisplayMember = "Name";
            companiesComboBox.ValueMember = "Name";
            companiesComboBox.SelectedIndex = -1;
        }

        private void CompaniesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var company = ((Company)comboBox.SelectedItem);

            var divisions = _database.GetDivisions(Convert.ToInt32(company.Id));

            divisionsComboBox.DataSource = divisions.Count() > 0 ? divisions : null;
            divisionsComboBox.DisplayMember = "Name";
            divisionsComboBox.ValueMember = "Name";
            divisionsComboBox.SelectedIndex = -1;
        }

        private void DivisionsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var division = ((Division)comboBox.SelectedItem);

            if (division == null) return;

            var projects = _database.GetProjects(division.Id);

            projectsComboBox.DataSource = projects.Count() > 0 ? projects : null;
            projectsComboBox.DisplayMember = "Name";
            projectsComboBox.ValueMember = "Name";
            projectsComboBox.SelectedIndex = -1;
        }

        private void ProjectsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var project = ((Project)comboBox.SelectedItem);

            if (project == null) return;

            var departments = _database.GetDepartments(project.Id);

            departmentsComboBox.DataSource = departments.Count() > 0 ? departments : null;
            departmentsComboBox.DisplayMember = "Name";
            departmentsComboBox.ValueMember = "Name";
            departmentsComboBox.SelectedIndex = -1;
        }
    }
}
