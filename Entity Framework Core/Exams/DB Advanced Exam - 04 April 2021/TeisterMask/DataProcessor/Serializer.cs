namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.XMLConvertHelper;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            const string rootEl = "Projects";

            var projectsWithTasks = context.Projects
                .Where(p => p.Tasks.Any())
                .ToArray()
                .Select(p => new ProjectWithTasksExportDto
                {
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    TasksCount = p.Tasks.Count,
                    Tasks = p.Tasks
                    .ToArray()
                    .Select(t => new TasksExportDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToList();

            return XMLConverter.Serialize(projectsWithTasks, rootEl);
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
               .Employees
               .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
               .ToArray()
               .Select(e => new
               {
                   e.Username,
                   Tasks = e.EmployeesTasks
                       .Where(et => et.Task.OpenDate >= date)
                       .ToArray()
                       .OrderByDescending(et => et.Task.DueDate)
                       .ThenBy(et => et.Task.Name)
                       .Select(et => new
                       {
                           TaskName = et.Task.Name,
                           OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                           DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                           LabelType = et.Task.LabelType.ToString(),
                           ExecutionType = et.Task.ExecutionType.ToString()
                       })
                       .ToArray()
               })
               .OrderByDescending(e => e.Tasks.Length)
               .ThenBy(e => e.Username)
               .Take(10)
               .ToArray();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}