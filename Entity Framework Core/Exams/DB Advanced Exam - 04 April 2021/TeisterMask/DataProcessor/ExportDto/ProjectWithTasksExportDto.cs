namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ProjectWithTasksExportDto
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public TasksExportDto[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class TasksExportDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }
    }

    //<Project TasksCount = "10" >
    //< ProjectName > Hyster - Yale </ ProjectName >
    //< HasEndDate > No </ HasEndDate >
    //< Tasks >
    //  < Task >
    //    < Name > Broadleaf </ Name >
    //    < Label > JavaAdvanced </ Label >
    //  </ Task >

}
