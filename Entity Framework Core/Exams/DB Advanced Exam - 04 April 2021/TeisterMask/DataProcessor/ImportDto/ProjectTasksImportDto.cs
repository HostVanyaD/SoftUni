namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using TeisterMask.Shared;

    [XmlType("Task")]
    public class ProjectTasksImportDto
    {
        [Required]
        [MinLength(GlobalConstants.TaskNameMinLength)]
        [MaxLength(GlobalConstants.ProjectNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Range(0, 3)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Range(0, 4)]
        public int LabelType { get; set; }
    }

  //    <Task>
  //      <Name>Upland Boneset</Name>
  //      <OpenDate>24/10/2018</OpenDate>
  //      <DueDate>11/06/2019</DueDate>
  //      <ExecutionType>2</ExecutionType>
  //      <LabelType>3</LabelType>
  //    </Task>
}