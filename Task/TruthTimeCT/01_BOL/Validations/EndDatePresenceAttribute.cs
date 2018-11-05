using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL.Validations
{
    public class EndDatePresenceAttribute : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime startDatePresence = (validationContext.ObjectInstance as DailyPresence).StartDatePresence;
            DateTime endDatePresence = (DateTime)value;
            return ((endDatePresence - startDatePresence).TotalHours >= 0) ? null :
                new ValidationResult("EndDateTime has to be bigger than StartDateTime");
        }

    }
}
