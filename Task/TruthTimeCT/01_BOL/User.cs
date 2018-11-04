using _01_BOL.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _01_BOL
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Id User is Required")]
        public int IdUser { get; set; }
        [MinLength(5),MaxLength(20)]
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [MinLength(8),MaxLength(8)]
        //[UserAttribute]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Id Status is Required")]
        public int IdStatus { get; set; }
        public StatusUser StatusUserFK { get; set; }
        [DefaultValue(0)]
        public int SumHours { get; set; }
        public int? IdTeamLeader { get; set; }
        [Required(ErrorMessage = "IsManager is Required")]
        public bool IsManager { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public  string EmailUser { get; set; }
    }
}


