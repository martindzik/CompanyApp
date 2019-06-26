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
    public partial class AddDepartmentForm : Form
    {
        private readonly Database _database = new Database();

        public AddDepartmentForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text.Length != 0 && projectComboBox.SelectedValue != null && leaderComboBox.SelectedValue != null)
            {
                var department = new Department(
                1,
                nameTextBox.Text,
                Convert.ToInt32(projectComboBox.SelectedValue),
                Convert.ToInt32(leaderComboBox.SelectedValue)
                );

                _database.AddDepartment(department);

                this.Close();
            }
            else
            {
                MessageBox.Show("Vyplňte všetky polia");
            }
        }

        private void AddDepartmentForm_Load(object sender, EventArgs e)
        {
            var projectDtos = _database.GetAllProjects();

            projectComboBox.DataSource = projectDtos;
            projectComboBox.DisplayMember = "Name";
            projectComboBox.ValueMember = "Id";
            projectComboBox.SelectedIndex = -1;

            var employeeDtos = _database.GetAllEmployees();

            leaderComboBox.DataSource = employeeDtos;
            leaderComboBox.DisplayMember = "Name";
            leaderComboBox.ValueMember = "Id";
            leaderComboBox.SelectedIndex = -1;
        }
    }
}
