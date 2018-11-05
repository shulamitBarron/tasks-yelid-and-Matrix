using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BOL.Validations
{
    class EndDateProjectAttribute: ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime startDateProject = (validationContext.ObjectInstance as Project).StartDate;
            DateTime endDateProject = (DateTime)value;
            return ((endDateProject - startDateProject).TotalHours >= 0) ? null :
                new ValidationResult("EndDateTime has to be bigger than StartDateTime");
        }
    }
}
