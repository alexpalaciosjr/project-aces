// Models/ValidationRule.cs
namespace webserver.Models
{
    public class ValidationRule
    {
        public int Rule_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Regex { get; set; }
    }
}