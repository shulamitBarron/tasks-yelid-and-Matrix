using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL.HelpDepartment
{
   public class UserProjectHelp
    {
        [Key]
        public int IdUserProject { get; set; }

        public int HoursProjectUser { get; set; }
    
        public int IdUser { get; set; }
     
        public int IdProject { get; set; }
        public string NameProject { get; set; }
        public string NameUser { get; set; }
    }
}
