using CompanyApp.DbWrapper;
using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyApp
{
    public partial class EditEmployeeForm : Form
    {
        private readonly Database _database = new Database();
        public int EmployeeId { get; set; }

        public EditEmployeeForm(int employeeId)
        {
            EmployeeId = employeeId;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var employee = _database.GetEmployee(EmployeeId);

            if (nameTextBox.Text.Length != 0
                && surnameTextBox.Text.Length != 0
                && phoneTextBox.Text.Length != 0
                && emailTextBox.Text.Length != 0
                && positionTextBox.Text.Length != 0
                && departmentComboBox.SelectedValue != null)
            {
                employee.Id = employee.Id;
                employee.Title = titleTextBox.Text;
                employee.Name = nameTextBox.Text;
                employee.Surname = surnameTextBox.Text;
                employee.PhoneNumber = phoneTextBox.Text;
                employee.Email = emailTextBox.Text;
                employee.Position = positionTextBox.Text;
                employee.DepartmentId = (int)departmentComboBox.SelectedValue;

                _database.EditEmpoyee(employee);

                this.Close();
            }
            else
            {
                MessageBox.Show("Vyplňte všetky polia");
            }    
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            var employee = _database.GetEmployee(EmployeeId);

            var departmentDtos = _database.GetAllDepartments();

            titleTextBox.Text = employee.Title;
            nameTextBox.Text = employee.Name;
            surnameTextBox.Text = employee.Surname;
            phoneTextBox.Text = employee.PhoneNumber;
            emailTextBox.Text = employee.Email;
            positionTextBox.Text = employee.Position;

            departmentComboBox.DataSource = departmentDtos;
            departmentComboBox.DisplayMember = "Name";
            departmentComboBox.ValueMember = "Id";
            departmentComboBox.SelectedValue = employee.DepartmentId;
        }
    }
}
