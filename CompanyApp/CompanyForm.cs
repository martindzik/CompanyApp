using CompanyApp.DbWrapper;
using CompanyApp.Helpers;
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

        private void CompanyForm_Shown(object sender, EventArgs e)
        {
            var companies = _database.GetCompanies();

            companiesComboBox.DataSource = companies;
            companiesComboBox.DisplayMember = "Name";
            companiesComboBox.ValueMember = "Id";
            companiesComboBox.SelectedIndex = -1;
        }

        private void CompaniesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var company = ((Company)comboBox.SelectedItem);

            var divisions = _database.GetDivisions(Convert.ToInt32(company.Id));

            divisionsComboBox.DataSource = divisions.Count() > 0 ? divisions : null;
            divisionsComboBox.DisplayMember = "Name";
            divisionsComboBox.ValueMember = "Id";
            divisionsComboBox.SelectedIndex = -1;

            projectsComboBox.DataSource = null;
            departmentsComboBox.DataSource = null;

            ShowEmployees();
        }

        private void DivisionsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var division = ((Division)comboBox.SelectedItem);

            if (division == null) return;

            var projects = _database.GetProjects(division.Id);

            projectsComboBox.DataSource = projects.Count() > 0 ? projects : null;
            projectsComboBox.DisplayMember = "Name";
            projectsComboBox.ValueMember = "Id";
            projectsComboBox.SelectedIndex = -1;

            departmentsComboBox.DataSource = null;

            ShowEmployees();
        }

        private void ProjectsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var project = (Project)comboBox.SelectedItem;

            if (project == null) return;

            var departments = _database.GetDepartments(project.Id);

            departmentsComboBox.DataSource = departments.Count() > 0 ? departments : null;
            departmentsComboBox.DisplayMember = "Name";
            departmentsComboBox.ValueMember = "Id";
            departmentsComboBox.SelectedIndex = -1;

            ShowEmployees();
        }

        private void DepartmentsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var department = (Department)comboBox.SelectedItem;

            if (department == null) return;

            ShowEmployees();
        }

        private void ShowEmployees()
        { 
            var selectedCompany = companiesComboBox.SelectedValue == null ? null : companiesComboBox.SelectedValue.ToString();
            var selectedDivision = divisionsComboBox.SelectedValue == null ? null : divisionsComboBox.SelectedValue.ToString();
            var selectedProject = projectsComboBox.SelectedValue == null ? null : projectsComboBox.SelectedValue.ToString();
            var selectedDepartment = departmentsComboBox.SelectedValue == null ? null : departmentsComboBox.SelectedValue.ToString();

            var filter = new Filter(selectedCompany, selectedDivision, selectedProject, selectedDepartment);

            var employees = _database.GetEmployees(filter);

            var bindingList = new BindingList<Employee>(employees.ToList());
            var source = new BindingSource(bindingList, null);

            employeesDataGridView.DataSource = source;
            employeesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetUpDataGridViewColumns();
        }

        private void SetUpDataGridViewColumns()
        {
            if(employeesDataGridView.CurrentCell != null)
            {
                employeesDataGridView.CurrentCell.Selected = false;
            }
            
            employeesDataGridView.Columns["Id"].Width = 40;
            employeesDataGridView.Columns["Title"].Width = 50;
            employeesDataGridView.Columns["Name"].Width = 80;
            employeesDataGridView.Columns["Surname"].Width = 80;
            employeesDataGridView.Columns["PhoneNumber"].Width = 120;
            employeesDataGridView.Columns["Email"].Width = 140;
            employeesDataGridView.Columns["Position"].Width = 160;
            employeesDataGridView.Columns["Id"].Visible = false;
            employeesDataGridView.Columns["DepartmentId"].Visible = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            addEmployeeForm.Show();
        }

        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            ShowEmployees();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var row = employeesDataGridView.SelectedRows[0];
            var employeeId = (int) row.Cells["Id"].Value;

            _database.DeleteEmployee(employeeId);
            employeesDataGridView.Rows.Remove(row);       
        }
    }
}
