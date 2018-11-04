using _01_BOL.Validations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _01_BOL
{
    public class Project
    {
        [Key]
        public int IdProject { get; set; }
        [Required(ErrorMessage = "ProjectName is Required")]
        [UniqueProjectNameAttribute]
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public int IdTeamLeader { get; set; }
        [Required(ErrorMessage = "HoursForProject is Required")]
        public double HoursForDevelopers { get; set; }
        public double HoursForQA { get; set; }
        public double HoursForUI_UX { get; set; }
        public bool Active { get; set; } = true;
        [Required(ErrorMessage = "StartDate Project is Required")]
        public DateTime StartDate { get; set; }
        [EndDateProjectAttribute]
        [Required(ErrorMessage = "EndDate Project is Required")]
        public DateTime EndDate { get; set; }

    }
}
