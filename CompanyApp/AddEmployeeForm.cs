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
    public partial class AddEmployeeForm : Form
    {
        private readonly Database _database = new Database();
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var employee = new Employee(
                1,
                titleTextBox.Text,
                nameTextBox.Text,
                surnameTextBox.Text,
                phoneTextBox.Text,
                emailTextBox.Text,
                positionTextBox.Text,
                Convert.ToInt32(departmentComboBox.SelectedValue)
            );

            _database.AddEmployee(employee);

            this.Close();
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            var departmentDtos = _database.GetAllDepartments();

            departmentComboBox.DataSource = departmentDtos;
            departmentComboBox.DisplayMember = "Name";
            departmentComboBox.ValueMember = "Id";
            departmentComboBox.SelectedIndex = -1;
        }
    }
}
