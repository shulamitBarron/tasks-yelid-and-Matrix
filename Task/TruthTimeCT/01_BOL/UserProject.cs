using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL
{
    public class UserProject
    {
        [Required(ErrorMessage = "Id User Project is Required")]
        public int IdUserProject { get; set; }
        [DefaultValue(0)]
        public int HoursProjectUser { get; set; }
        [Required(ErrorMessage = "Id User is Required")]
        public int IdUser { get; set; }
        [Required(ErrorMessage = "Id Project is Required")]
        public int IdProject { get; set; }
    }
}


