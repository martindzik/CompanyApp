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
    public partial class AddDivisionForm : Form
    {
        private readonly Database _database = new Database();

        public AddDivisionForm()
        {
            InitializeComponent();
        }

        private void AddDivisionForm_Load(object sender, EventArgs e)
        {
            var companyDtos = _database.GetAllCompanies();

            companyComboBox.DataSource = companyDtos;
            companyComboBox.DisplayMember = "Name";
            companyComboBox.ValueMember = "Id";
            companyComboBox.SelectedIndex = -1;

            var employeeDtos = _database.GetAllEmployees();

            leaderComboBox.DataSource = employeeDtos;
            leaderComboBox.DisplayMember = "Name";
            leaderComboBox.ValueMember = "Id";
            leaderComboBox.SelectedIndex = -1;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text.Length != 0 && companyComboBox.SelectedValue != null && leaderComboBox.SelectedValue != null)
            {
                var division = new Division(
                1,
                nameTextBox.Text,
                Convert.ToInt32(companyComboBox.SelectedValue),
                Convert.ToInt32(leaderComboBox.SelectedValue)
                );

                _database.AddDivision(division);

                this.Close();
            }
            else
            {
                MessageBox.Show("Vyplňte všetky polia");
            }
        }
    }
}
