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
    }
}
