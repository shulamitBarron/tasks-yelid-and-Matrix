using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _01_BOL.Validations
{
    class ExistUser : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           if(_userConverter.GetAllUsers().FirstOrDefault(u => u.UserName==value.ToString())!=null)
             return new ValidationResult("This Name: " + (value) + " exist");
            return null;
        }
        private readonly IAllUser _userConverter;

        public ExistUser(IAllUser userConverter)
        {
            _userConverter = userConverter;
        }

        public ExistUser()
            : this(ServiceLocator.Get<IAllUser>())
        {
        }
    }
    internal static class ServiceLocator
    {
        private static readonly CompositionContainer _container =
            new CompositionContainer(new DirectoryCatalog(@".\"));

        public static T Get<T>()
        {
            return _container.GetExportedValue<T>();
        }
    }
}
