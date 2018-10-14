using MemoryName.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemoryGame.Models
{
    public class User
    {
        [UniqueAttribute]
        [Required(ErrorMessage = "Name is Required")]
        [MinLength(2, ErrorMessage = "Name must be over than 2 characters")]
        [MaxLength(10, ErrorMessage = "Name must be less than 10 characters")]
        public string UserName { get; set; }
        [Range(18, 120, ErrorMessage = "Age must be between 18-120 in years.")]
        public int Age { get; set; }
        public string PartnerName { get; set; }
        [DefaultValue(0)]
        public int Score { get; set; }
    }
}