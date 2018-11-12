using _01_BOL.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_BOL
{
    public class DailyPresence
    {
        [Key]
        public int IdDaliyPresence { get; set; }
        [EndDatePresenceAttribute]
        [Column(TypeName ="Date")]
        [Required(ErrorMessage = "EndDate Presence is Required")]
        public DateTime EndDatePresence { get; set; }
        [StartDatePresenceAttribute]
        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "StartDate Presence is Required")]
        public DateTime StartDatePresence { get; set; }
        [Required(ErrorMessage = "Id User Project is Required")]
        public int IdUserProjectFK { get; set; }

    }
}


