// Models/Field.cs
namespace webserver.Models
{
    public class Field
    {
        public int alias { get; set; }
        public string appName { get; set; }
        public ValidationRule validationRule { get; set; }
    }
}