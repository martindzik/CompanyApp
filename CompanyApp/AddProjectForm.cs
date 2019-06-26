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
    public partial class AddProjectForm : Form
    {
        private readonly Database _database = new Database();

        public AddProjectForm()
        {
            InitializeComponent();
        }

        private void AddProjectForm_Load(object sender, EventArgs e)
        {
            var divisionDtos = _database.GetAllDivisions();

            divisionsComboBox.DataSource = divisionDtos;
            divisionsComboBox.DisplayMember = "Name";
            divisionsComboBox.ValueMember = "Id";
            divisionsComboBox.SelectedIndex = -1;

            var employeeDtos = _database.GetAllEmployees();

            leaderComboBox.DataSource = employeeDtos;
            leaderComboBox.DisplayMember = "Name";
            leaderComboBox.ValueMember = "Id";
            leaderComboBox.SelectedIndex = -1;
        }

        private void CancelProjectButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveProjectButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text.Length != 0 && divisionsComboBox.SelectedValue != null && leaderComboBox.SelectedValue != null)
            {
                var project = new Project(
                1,
                nameTextBox.Text,
                Convert.ToInt32(divisionsComboBox.SelectedValue),
                Convert.ToInt32(leaderComboBox.SelectedValue)
                );

                _database.AddProject(project);

                this.Close();
            }
            else
            {
                MessageBox.Show("Vyplňte všetky polia");
            }
        }


            
    }
}
