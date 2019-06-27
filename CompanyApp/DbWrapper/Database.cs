using CompanyApp.Dtos;
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

                    Int32.TryParse(reader["Id"].ToString().Trim(), out id);
                    name = reader["Name"].ToString().Trim();
                    Int32.TryParse(reader["DirectorId"].ToString().Trim(), out directorId);

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
                    Int32.TryParse(reader["Id"].ToString().Trim(), out int id);
                    var name = reader["Name"].ToString().Trim();
                    Int32.TryParse(reader["CompanyId"].ToString().Trim(), out int companyId);
                    Int32.TryParse(reader["ManagerId"].ToString().Trim(), out int managerId);

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
                command.Parameters.AddWithValue("@DivisionId", divisionId);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString().Trim(), out int id);
                    var name = reader["Name"].ToString().Trim();
                    Int32.TryParse(reader["DivisionId"].ToString().Trim(), out int divId);
                    Int32.TryParse(reader["LeaderId"].ToString().Trim(), out int leaderId);

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
                command.Parameters.AddWithValue("@ProjectId", projectId);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString().Trim(), out int id);
                    var name = reader["Name"].ToString().Trim();
                    Int32.TryParse(reader["ProjectId"].ToString().Trim(), out int projId);
                    Int32.TryParse(reader["LeaderId"].ToString().Trim(), out int leaderId);

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
            else
            {
                return null;
            }

            using(var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(cmd, connection);

                switch (choice)
                {
                    case 1:
                        command.Parameters.AddWithValue("@DepartmentId", selectedDepartmentId);
                        break;
                    case 2:
                        command.Parameters.AddWithValue("@ProjectId", selectedProjectId);
                        break;
                    case 3:
                        command.Parameters.AddWithValue("@DivisionId", selectedDivisionId);
                        break;
                    case 4:
                        command.Parameters.AddWithValue("@CompanyId", selectedCompanyId);
                        break;
                }

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString().Trim(), out int id);
                    var title = reader["Title"].ToString().Trim();
                    var name = reader["Name"].ToString().Trim();
                    var surname = reader["Surname"].ToString().Trim();
                    var phoneNumber = reader["PhoneNumber"].ToString().Trim();
                    var email = reader["Email"].ToString().Trim();
                    var position = reader["Position"].ToString().Trim();
                    Int32.TryParse(reader["DepartmentId"].ToString().Trim(), out int departmendId);

                    var employee = new Employee(id, title, name, surname, phoneNumber, email, position, departmendId);

                    employees.Add(employee);
                }
            }

            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(
                    "INSERT INTO Employees " +
                    "VALUES (@Title, @Name, @Surname, @PhoneNumber, @Email, @Position, @DepartmentId)",
                    connection
                    );

                command.Parameters.AddWithValue("@Title", employee.Title);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditEmpoyee(Employee employee)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("UPDATE Employees SET " +
                    "Title = @Title, " +
                    "Name = @Name, " +
                    "Surname = @Surname, " +
                    "PhoneNumber = @PhoneNumber, " +
                    "Email = @Email, " +
                    "Position = @Position, " +
                    "DepartmentId = @DepartmentId " +
                    "WHERE Id = @Id",
                    connection
                    );

                command.Parameters.AddWithValue("@Title", employee.Title);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                command.Parameters.AddWithValue("@Id", employee.Id);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddProject(Project project)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(
                    "INSERT INTO Projects " + 
                    "VALUES (@Name, @DivisionId, @LeaderId)",
                    connection
                    );

                command.Parameters.AddWithValue("@Name", project.Name);
                command.Parameters.AddWithValue("@DivisionId", project.DivisionId);
                command.Parameters.AddWithValue("@LeaderId", project.LeaderId);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddDivision(Division division)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(
                    "INSERT INTO Divisions " +
                    "VALUES (@Name, @CompanyId, @ManagerId)",
                    connection
                    );

                command.Parameters.AddWithValue("@Name", division.Name);
                command.Parameters.AddWithValue("@CompanyId", division.CompanyId);
                command.Parameters.AddWithValue("@ManagerId", division.ManagerId);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddDepartment(Department department)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(
                    "INSERT INTO Departments " +
                    "VALUES (@Name, @ProjectId, @LeaderId)",
                    connection
                    );

                command.Parameters.AddWithValue("@Name", department.Name);
                command.Parameters.AddWithValue("@ProjectId", department.ProjectId);
                command.Parameters.AddWithValue("@LeaderId", department.LeaderId);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departmentDtos = new List<DepartmentDto>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT Id, Name FROM Departments", connection);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString().Trim(), out int id);
                    var name = reader["Name"].ToString().Trim();

                    var department = new DepartmentDto(id, name);

                    departmentDtos.Add(department);
                }
            }

            return departmentDtos;
        }

        public IEnumerable<DivisionDto> GetAllDivisions()
        {
            var divisionDtos = new List<DivisionDto>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT Id, Name FROM Divisions", connection);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString().Trim(), out int id);
                    var name = reader["Name"].ToString().Trim();

                    var division = new DivisionDto(id, name);

                    divisionDtos.Add(division);
                }
            }

            return divisionDtos;
        }

        public IEnumerable<Leader> GetAllLeaders()
        {
            var leaders = new List<Leader>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT * FROM Leaders", connection);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString().Trim(), out int id);
                    var title = reader["Title"].ToString().Trim();
                    var name = reader["Name"].ToString().Trim();
                    var surname = reader["Surname"].ToString().Trim();

                    var leader = new Leader(id, title, name, surname);

                    leaders.Add(leader);
                }
            }

            return leaders;
        }

        public IEnumerable<CompanyDto> GetAllCompanies()
        {
            var companyDtos = new List<CompanyDto>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT Id, Name FROM Companies", connection);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString().Trim(), out int id);
                    var name = reader["Name"].ToString().Trim();

                    var company = new CompanyDto(id, name);

                    companyDtos.Add(company);
                }
            }

            return companyDtos;
        }

        public IEnumerable<ProjectDto> GetAllProjects()
        {
            var projectDtos = new List<ProjectDto>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT Id, Name FROM Projects", connection);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString().Trim(), out int id);
                    var name = reader["Name"].ToString().Trim();

                    var project = new ProjectDto(id, name);

                    projectDtos.Add(project);
                }
            }

            return projectDtos;
        }

        public Leader GetLeader(int leaderId)
        {
            int id = 0;
            string title = "";
            string name = "";
            string surname = "";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT * FROM Leaders WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", leaderId);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Int32.TryParse(reader["Id"].ToString().Trim(), out id);
                    title = reader["Title"].ToString().Trim();
                    name = reader["Name"].ToString().Trim();
                    surname = reader["Surname"].ToString().Trim();
                }
            }

            return new Leader(id, title, name, surname);
        }

        public void DeleteEmployee(int id)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("UPDATE Departments SET LeaderId = NULL WHERE LeaderId = @LeaderId", connection);
                command.Parameters.AddWithValue("@LeaderId", id);
                command.Connection.Open();
                command.ExecuteNonQuery();

                command = new SqlCommand("UPDATE Projects SET LeaderId = NULL WHERE LeaderId = @LeaderId", connection);
                command.Parameters.AddWithValue("@LeaderId", id);
                command.ExecuteNonQuery();


                command = new SqlCommand("UPDATE Divisions SET ManagerId = NULL WHERE ManagerId = @ManagerId", connection);
                command.Parameters.AddWithValue("@ManagerId", id);
                command.ExecuteNonQuery();

                command = new SqlCommand("UPDATE Companies SET DirectorId = NULL WHERE DirectorId = @DirectorId", connection);
                command.Parameters.AddWithValue("@DirectorId", id);
                command.ExecuteNonQuery();


                command = new SqlCommand("DELETE FROM Employees WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public Employee GetEmployee(int id)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("SELECT * FROM Employees WHERE id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.Connection.Open();
                var reader = command.ExecuteReader();

                reader.Read();
                
                var employeeId = (int)reader["Id"];
                var title = reader["Title"].ToString().Trim();
                var name = reader["Name"].ToString().Trim();
                var surname = reader["Surname"].ToString().Trim();
                var phoneNumber = reader["PhoneNumber"].ToString().Trim();
                var email = reader["Email"].ToString().Trim();
                var position = reader["Position"].ToString().Trim();
                var departmentId = (int)reader["DepartmentId"];

                var employee = new Employee(employeeId, title, name, surname, phoneNumber, email, position, departmentId);

                return employee;
            }
        }
    }
}
