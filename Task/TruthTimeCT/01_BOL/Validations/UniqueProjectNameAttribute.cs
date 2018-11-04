using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace _01_BOL.Validations
{
    class UniqueProjectNameAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                int idProject = (validationContext.ObjectInstance as Project).IdProject;
                string nameProject = value.ToString();
                Assembly assembly = Assembly.LoadFrom(@"G:\TruthTimeCT\02_BLL\bin\Debug\02_BLL.dll");
                Type projectServiceType = assembly.GetTypes().First(t => t.Name.Equals("LogicProjects"));
                MethodInfo getAllUsersMethod = projectServiceType.GetMethods().First(m => m.Name.Equals("GetAllProjects"));
                List<Project> projects = getAllUsersMethod.Invoke(Activator.CreateInstance(projectServiceType), new object[] { }) as List<Project>;
                if (projects == null) return validationResult;//there are not project yet
                bool isUnique = projects.Any(project => project.ProjectName==nameProject && project.IdProject != idProject) == false;
                if (isUnique == false)
                {
                    ErrorMessage = "project name must be unique";
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
