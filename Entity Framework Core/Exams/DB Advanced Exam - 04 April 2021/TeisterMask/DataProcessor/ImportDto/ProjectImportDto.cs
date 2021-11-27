namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using TeisterMask.Shared;

    [XmlType("Project")]
    public class ProjectImportDto
    {
        [Required]
        [MinLength(GlobalConstants.ProjectNameMinLength)]
        [MaxLength(GlobalConstants.ProjectNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public ProjectTasksImportDto[] Tasks { get; set; }
    }
}
