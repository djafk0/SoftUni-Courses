namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;
    using SoftUni.Models;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();
            string result = DeleteProjectById(softUniContext);

            Console.WriteLine(result);
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Employee[] employee = context
                .Employees
                .ToArray();


            foreach (var item in employee.OrderBy(x => x.EmployeeId))
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} {item.MiddleName} {item.JobTitle} {item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context
                .Employees
                .OrderBy(e => e.FirstName)
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();


            foreach (var item in employee)
            {
                sb.AppendLine($"{item.FirstName} - {item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary
                })
                .ToArray();


            foreach (var item in employee)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} from {item.Department.Name} - ${item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)


        {
            Address address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4;

            context.Addresses.Add(address);

            Employee employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            var result = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Select(x => x.Address.AddressText)
                .Take(10)
                .ToArray();


            return string.Join('\n', result);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var result = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStart = ep.Project.StartDate,
                        ProjectEnd = ep.Project.EndDate
                    })
                })
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var names in result)
            {
                sb.AppendLine($"{names.FirstName} {names.LastName} - Manager: {names.ManagerFirstName} {names.ManagerLastName}");

                foreach (var item in names.Projects)
                {
                    var startDate = item.ProjectStart.ToString("M/d/yyyy h:mm:ss tt");
                    var endDate = item.ProjectEnd.HasValue ? item.ProjectEnd.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";

                    sb.AppendLine($"--{item.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var result = context
                .Addresses
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.AddressText}, {item.TownName} - {item.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var result = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name
                    })
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var name in result)
            {
                sb.AppendLine($"{name.FirstName} {name.LastName} - {name.JobTitle}");

                foreach (var projects in name.Projects.OrderBy(e => e.ProjectName))
                {
                    sb.AppendLine(projects.ProjectName);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var result = context
                .Departments
                .Where(e => e.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenBy(e => e.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    JobTitles = d.Employees.Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        JobTitle = e.JobTitle
                    })
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.DepartmentName} - {item.ManagerFirstName} {item.ManagerLastName}");

                foreach (var item2 in item.JobTitles.OrderBy(o => o.EmployeeFirstName).ThenBy(o => o.EmployeeLastName))
                {
                    sb.AppendLine($"{item2.EmployeeFirstName} {item2.EmployeeLastName} - {item2.JobTitle}");
                }
            }

            return sb.ToString().ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var result = context
                .Projects
                .OrderByDescending(p => p.StartDate).
                Take(10)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate
                })
                .OrderBy(n => n.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var item in result.OrderBy(x => x.Name))
            {
                sb.AppendLine($"{item.Name}");
                sb.AppendLine($"{item.Description}");
                sb.AppendLine($"{item.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var result = context
                .Employees
                .Where(e =>
                e.Department.Name == "Engineering" ||
                e.Department.Name == "Tool Design" ||
                e.Department.Name == "Marketing" ||
                e.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                decimal salary = item.Salary * 1.12m;
                sb.AppendLine($"{item.FirstName} {item.LastName} (${salary:F2})");

            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var result = context
                .Employees
                .Where(e => e.FirstName.Substring(0, 2) == "Sa")
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle} - (${item.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeeProject = context
                .EmployeesProjects
                .FirstOrDefault(e => e.ProjectId == 2);

            var delete = context
                .EmployeesProjects
                .Remove(employeeProject);

            context.SaveChanges();

            var result = context
                .Projects
                .Take(10)
                .Select(e => new
                {
                    e.Name,
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            Town town = context
                .Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            var addresses = context
                .Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToArray();

            foreach (var item in addresses)
            {
                var currAddress = context
                    .Addresses
                    .Remove(item);
            }

            context.SaveChanges();

            var removeTown = context
                .Towns
                .Remove(town);

            context.SaveChanges();

            return $"{addresses.Length} addresses in Seattle were deleted";
        }
    }
}
