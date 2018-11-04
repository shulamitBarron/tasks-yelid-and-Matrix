using _01_BOL.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
namespace _01_BOL
{
    public class DailyPresence
    {
        [Key]
        [Required(ErrorMessage = "Id Daliy Presence is Required")]
        public int IdDaliyPresence { get; set; }
        [EndDatePresenceAttribute]
        [Required(ErrorMessage = "EndDate Presence is Required")]
        public DateTime EndDatePresence { get; set; }
        [StartDatePresenceAttribute]
        [Required(ErrorMessage = "StartDate Presence is Required")]
        public DateTime StartDatePresence { get; set; }
        [Required(ErrorMessage = "Id User Presence is Required")]
        public int IdUserFK { get; set; }
        public User IdUser { get; set; }
        [Required(ErrorMessage = "Id Project is Required")]
        public int IdProjectFK { get; set; }
        public Project IdProject { get; set; }
    }
}


