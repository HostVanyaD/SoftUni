namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                //Restore(context);
                string result = RemoveTown(context);
                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var allEmployees = context.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.Id);

            foreach (var employee in allEmployees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var allEmployees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FirstName);

            foreach (var employee in allEmployees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var allEmployees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (var employee in allEmployees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:F2}");
            }

            return result.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employeeToUpdate = context.Employees
                .Where(e => e.LastName == "Nakov")
                .FirstOrDefault();

            employeeToUpdate.Address = newAddress;

            context.SaveChanges();

            StringBuilder result = new StringBuilder();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new { AddressText = e.Address.AddressText });

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.AddressText}");
            }

            return result.ToString().Trim();
        }

        public static void Restore(SoftUniContext context)
        {
            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.AddressId = 291;

            var addressToDelete = context.Addresses
                .Where(a => a.AddressText == "Vitoshka 15");

            context.RemoveRange(addressToDelete.ToList());

            context.SaveChanges();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employeesByPeriod = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FullName = string.Concat(e.FirstName, " ", e.LastName),
                    ManagerFullName = string.Concat(e.Manager.FirstName, " ", e.Manager.LastName),
                    Projects = e.EmployeesProjects
                            .Select(ep => new
                            {
                                ProjectName = ep.Project.Name,
                                StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                                EndDate = ep.Project.EndDate
                            })
                })
                .Take(10);

            foreach (var employee in employeesByPeriod)
            {
                result.AppendLine($"{employee.FullName} - Manager: {employee.ManagerFullName}");

                foreach (var project in employee.Projects)
                {
                    result.Append($"--{project.ProjectName} - {project.StartDate} - ");

                    if (project.EndDate == null)
                    {
                        result.AppendLine("not finished");
                    }
                    else
                    {
                        result.AppendLine($"{project.EndDate:M/d/yyyy h:mm:ss tt}");
                    }
                }
            }

            return result.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var addressesByTown = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .Take(10)
                .ToList();

            foreach (var address in addressesByTown)
            {
                result.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employeeInfo147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => p.Project)
                })
                .First();

            result.AppendLine($"{employeeInfo147.FirstName} {employeeInfo147.LastName} - {employeeInfo147.JobTitle}");

            foreach (var project in employeeInfo147.Projects.OrderBy(p => p.Name))
            {
                result.AppendLine($"{project.Name}");
            }

            return result.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new { e.FirstName, e.LastName, e.JobTitle })
                });

            foreach (var dep in departments)
            {
                result.AppendLine($"{dep.Name} - {dep.ManagerFirstName}  {dep.ManagerLastName}");

                foreach (var e in dep.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return result.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var latestProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                })
                .OrderBy(p => p.Name)
                .ToArray();

            foreach (var project in latestProjects)
            {
                result.AppendLine($"{project.Name}");
                result.AppendLine($"{project.Description}");
                result.AppendLine($"{project.StartDate}");
            }

            return result.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            //Engineering, Tool Design, Marketing, or Information Services

            var employeesToPromote = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in employeesToPromote)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            foreach (var e in employeesToPromote)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employeesToDisplay = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in employeesToDisplay)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return result.ToString().Trim();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employeesProjectToDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToArray();

            context.EmployeesProjects.RemoveRange(employeesProjectToDelete);

            var projectToDelete = context.Projects
                .Find(2);

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects.Take(10);

            foreach (var p in projects)
            {
                result.AppendLine($"{p.Name}");
            }

            return result.ToString().Trim();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var seattleAddresses = context
                .Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToArray();

            var employeesInSeattle = context
                .Employees
                .ToArray()
                .Where(e => seattleAddresses.Any(a => a.AddressId == e.AddressId))
                .ToArray();

            foreach (Employee employee in employeesInSeattle)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(seattleAddresses);

            Town seattleTown = context
                .Towns
                .First(t => t.Name == "Seattle");

            context.Towns.Remove(seattleTown);

            context.SaveChanges();

            return $"{seattleAddresses.Length} addresses in Seattle were deleted";
        }
    }
}
