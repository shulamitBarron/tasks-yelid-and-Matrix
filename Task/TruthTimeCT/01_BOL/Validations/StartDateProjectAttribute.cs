using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL.Validations
{
    
    class StartDateProjectAttribute : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime startProject = (DateTime)value;
            return ((startProject - DateTime.Now).TotalHours <= 0) ? null : new ValidationResult("DateTime has to be smaller than today");
        }
    }
}
