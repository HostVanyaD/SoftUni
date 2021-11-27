namespace TeisterMask.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EmployeeTask
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
