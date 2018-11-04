using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _01_BOL
{
   public class StatusUser
    {
        [Key]
        [Required(ErrorMessage = "Id Status is Required")]
        public int IdStatus { get; set; }
        [Required(ErrorMessage = "Status Name is Required")]
        public string StatusName { get; set; }
    }
}
