using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL.HelpModels
{
    public class UserHelp
    {
        [MinLength(5), MaxLength(20)]
        [Required(ErrorMessage = "User Name is Required")]
        public string  UserName{ get; set; }
        [MinLength(8), MaxLength(8)]
        [Required(ErrorMessage = "Password is Required")]
        public string  Password{ get; set; }
    }
}
