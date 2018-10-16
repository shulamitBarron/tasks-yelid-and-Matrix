using _01_BOL.Validations;
using System.ComponentModel.DataAnnotations;

namespace _01_BOL
{
    public class User
    {

        public int Id { get; set; }

        //4- 12 chars
        //requierd
        [Required]
        [ExistUser]
        public string UserName { get; set; }




        public int Age { get; set; }

    }
}
