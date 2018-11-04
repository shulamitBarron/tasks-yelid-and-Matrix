using System.ComponentModel.DataAnnotations;

namespace _01_BOL
{
    public class Project
    {

        [Required]
        public int IdProject { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public int IdManagerProject { get; set; }
        [Required]
        public int HoursForProject { get; set; }
       
    }
}
