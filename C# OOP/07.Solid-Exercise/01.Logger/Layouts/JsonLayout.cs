namespace _01.Logger.Layouts
{
    using System.Text;

    public class JsonLayout : ILayout
    {
        public string Template
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(@"""log"": {{");
                sb.AppendLine(@"  ""date"": ""{0}"",");
                sb.AppendLine(@"  ""level"": ""{1}"",");
                sb.AppendLine(@"  ""message"": ""{2}""");
                sb.AppendLine(@"}},");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
