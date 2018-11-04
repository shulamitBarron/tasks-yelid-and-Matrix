using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL.Validations
{
    
    public class StartDatePresenceAttribute : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime startPresence = (DateTime)value;
            return ((startPresence - DateTime.Now).TotalHours <= 0) ? null :new ValidationResult("DateTime has to be smaller than today");
        }

    }
}
