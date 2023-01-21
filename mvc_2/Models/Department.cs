using System.ComponentModel.DataAnnotations;

namespace mvc_2.Models
{
    public class Department
    {
        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }

        public List<location>? DepartmentLocations { get; set; }
        public List<project>? Projects { get; set; }
     
    }
}
