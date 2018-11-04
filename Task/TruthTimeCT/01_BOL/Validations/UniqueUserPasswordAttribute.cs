using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace _01_BOL.Validations
{
    class UserPasswordAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                int idUser = (validationContext.ObjectInstance as User).IdUser;
                string userPassword = value.ToString();
                Assembly assembly = Assembly.LoadFrom(@"E:\TruthTimeCT\02_BLL\bin\Debug\02_BLL.dll");
                Type userServiceType = assembly.GetTypes().First(t => t.Name.Equals("LogicUsers"));
                MethodInfo getAllUsersMethod = userServiceType.GetMethods().First(m => m.Name.Equals("GetAllUsers"));
                List<User> users = getAllUsersMethod.Invoke(Activator.CreateInstance(userServiceType), new object[] { }) as List<User>;
                bool isUnique = users.Any(user => user.Password == (userPassword) && user.IdUser != idUser) == false;
                if (isUnique == false)
                {
                    ErrorMessage = "user password must be unique";
                    validationResult = new ValidationResult(ErrorMessageString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return validationResult;
        }

    }
}
