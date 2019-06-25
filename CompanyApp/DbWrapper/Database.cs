using CompanyApp.Helpers;
using CompanyApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.DbWrapper
{
    public class Database
    {
        public string ConnectionString { get; } = @"Data Source=DESKTOP-6S7FKVF\SQLEXPRESS;Initial Catalog=CompanyDb;Integrated Security=True";

        public IEnumerable<Company> GetCompanies()
        {
            var companies = new List<Company>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT * FROM Companies", connection);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int id = 0;
                    string name = "";
                    int directorId = 0;

                    Int32.TryParse(reader["Id"].ToString(), out id);
                    name = reader["Name"].ToString();
                    Int32.TryParse(reader["DirectorId"].ToString(), out directorId);

                    var company = new Company(id, name, directorId);

                    companies.Add(company);
                }
            }

            return companies;
        }

        public IEnumerable<Division> GetDivisions(int compId)
        {
            var divisions = new List<Division>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT * FROM Divisions WHERE CompanyId = @CompanyId", connection);
                command.Parameters.AddWithValue("@CompanyId", compId);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                { 
                    Int32.TryParse(reader["Id"].ToString(), out int id);
                    var name = reader["Name"].ToString();
                    Int32.TryParse(reader["CompanyId"].ToString(), out int companyId);
                    Int32.TryParse(reader["ManagerId"].ToString(), out int managerId);

                    var division = new Division(id, name, companyId, managerId);

                    divisions.Add(division);
                }
            }

            return divisions;

        }

        public IEnumerable<Project> GetProjects(int divisionId)
        {
            var projects = new List<Project>();

            using(var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT * FROM Projects WHERE DivisionId = @DivisionId", connection);
                command.Parameters.AddWithValue("DivisionId", divisionId);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString(), out int id);
                    var name = reader["Name"].ToString();
                    Int32.TryParse(reader["DivisionId"].ToString(), out int divId);
                    Int32.TryParse(reader["LeaderId"].ToString(), out int leaderId);

                    var project = new Project(id, name, divId, leaderId);

                    projects.Add(project);
                }
            }

            return projects;
        }

        public IEnumerable<Department> GetDepartments(int projectId)
        {
            var departments = new List<Department>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT * FROM Departments WHERE ProjectId = @ProjectId", connection);
                command.Parameters.AddWithValue("ProjectId", projectId);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString(), out int id);
                    var name = reader["Name"].ToString();
                    Int32.TryParse(reader["ProjectId"].ToString(), out int projId);
                    Int32.TryParse(reader["LeaderId"].ToString(), out int leaderId);

                    var department = new Department(id, name, projId, leaderId);

                    departments.Add(department);
                }
            }

            return departments;
        }

        public IEnumerable<Employee> GetEmployees(Filter filter)
        {
            var employees = new List<Employee>();

            var cmd = "";

            var selectedCompanyId = filter.SelectedCompany;
            var selectedDivisionId = filter.SelectedDivision;
            var selectedProjectId = filter.SelectedProject;
            var selectedDepartmentId = filter.SelectedDepartment;

            var choice = 0;

            if(selectedDepartmentId != null)
            {
                cmd = "SELECT * FROM Employees WHERE DepartmentId = @DepartmentId";
                choice = 1;
            }
            else if(selectedProjectId != null)
            {
                cmd = "SELECT e.* FROM projects AS p " +
                    "JOIN departments AS d ON p.Id = d.ProjectId " +
                    "JOIN employees AS e ON d.Id = e.DepartmentId " +
                    "WHERE p.Id = @ProjectId";
                choice = 2;
            }
            else if(selectedDivisionId != null)
            {
                cmd = "SELECT e.* FROM divisions AS d " +
                    "JOIN projects AS p ON d.Id = p.DivisionId " +
                    "JOIN departments AS dep ON p.Id = dep.ProjectId " +
                    "JOIN employees AS e ON dep.Id = e.DepartmentId " +
                    "WHERE d.Id = @DivisionId";
                choice = 3;
            }
            else if(selectedCompanyId != null)
            {
                cmd = "SELECT e.* FROM companies as c " +
                    "JOIN divisions AS d ON c.Id = d.CompanyId " +
                    "JOIN projects AS p ON d.Id = p.DivisionId " +
                    "JOIN departments AS dep ON p.Id = dep.ProjectId " +
                    "JOIN employees AS e ON dep.Id = e.DepartmentId " +
                    "WHERE c.Id = @CompanyId";
                choice = 4;
            }

            using(var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(cmd, connection);

                switch (choice)
                {
                    case 1:
                        command.Parameters.AddWithValue("DepartmentId", selectedDepartmentId);
                        break;
                    case 2:
                        command.Parameters.AddWithValue("ProjectId", selectedProjectId);
                        break;
                    case 3:
                        command.Parameters.AddWithValue("DivisionId", selectedDivisionId);
                        break;
                    case 4:
                        command.Parameters.AddWithValue("CompanyId", selectedCompanyId);
                        break;
                }

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString(), out int id);
                    var title = reader["Title"].ToString();
                    var name = reader["Name"].ToString();
                    var surname = reader["Surname"].ToString();
                    var phoneNumber = reader["PhoneNumber"].ToString();
                    var email = reader["Email"].ToString();
                    var position = reader["Position"].ToString();
                    Int32.TryParse(reader["DepartmentId"].ToString(), out int departmendId);

                    var employee = new Employee(id, title, name, surname, phoneNumber, email, position, departmendId);

                    employees.Add(employee);
                }
            }

            return employees;
        }
    }
}
