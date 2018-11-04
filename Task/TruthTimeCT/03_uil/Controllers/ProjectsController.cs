using _01_BOL;
using _01_BOL.HelpDepartment;
using _02_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace _03_uil.Controllers
{
    public class MyClass
    {
        public List<User> Users { get; set; }
        public Dictionary<UserProject, double> MyGraf { get; set; }
    }

    public class ProjectsController : ApiController
    {
        // GET: api/Projects
        //List<UserProject> userProjects = LogicUserProject.GetAllUserProject();
        //List<Project> projects = LogicProjects.GetAllProjects();
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Project>>(LogicProjects.GetAllProjects(), new JsonMediaTypeFormatter())
            };
        }

        // GET: api/Projects/5
        public HttpResponseMessage Get(int id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<String>(LogicProjects.GetProjectName(id), new JsonMediaTypeFormatter())
            };
        }

        // POST: api/Projects
        public HttpResponseMessage Post([FromBody]Project value)
        {
            if (ModelState.IsValid)
            {
                return (LogicProjects.AddProject(value)) ?
                   new HttpResponseMessage(HttpStatusCode.Created) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                   };
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the Project is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };

        }

        // PUT: api/Projects/5
        public HttpResponseMessage Put([FromBody]Project value)
        {

            if (ModelState.IsValid)
            {
                return (LogicProjects.UpdateProject(value)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the Project is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };
        }

        // DELETE: api/Projects/5
        public HttpResponseMessage Delete(int id)
        {
            return (LogicProjects.RemoveProject(id)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }
        [HttpGet]
        [Route("api/Projects/GetAllProjectsUnderTheDirectionOfTheTeamLeader")]
        //return all project under teamLeader
        public HttpResponseMessage GetAllProjectsUnderTheDirectionOfTheTeamLeader(int idTeamLeader)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicProjects.GetProjectsUnderTheDirectionOfTheTeamLeader(idTeamLeader));
        }
        [HttpGet]
        [Route("api/Projects/GetHoursOfProject")]
        //return all hours under teamLeader
        public HttpResponseMessage GetHoursOfProject(int idProject)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicProjects.GetHoursOfProject(idProject));
        }
        [HttpGet]
        [Route("api/Projects/GetHoursThatUsersWorkedOfProject")]
        //return how many hours the users worked on spesipic project 
        public HttpResponseMessage GetHoursThatUsersWorkedOfProject(int idProject)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicProjects.GetHoursThatWorkedOfProject(idProject));
        }
        //return collection key idProject and value sum hours that the user worked on the project in precent
        [HttpGet]
        [Route("api/Projects/GetCollectionOfHoursThatUserWorkedOnProjectInPrecent")]
        public HttpResponseMessage GetCollectionOfHoursThatUserWorkedOnProjectInPrecent(int idUser)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Dictionary<UserProject, double>>(LogicProjects.GetDictionaryOfHoursThatUserWorkedOnProjectInPrecent(idUser), new JsonMediaTypeFormatter())
            };
        }
        //update project to active and export all data of project to excel file.
        [HttpPut]
        [Route("api/Projects/EndProject")]
        public HttpResponseMessage EndProject([FromBody]Project value)
        {
            // יצוא של קבצי אקסל למערכת של נתוני הפרויקט שהסתיים
            if (ModelState.IsValid)
            {
                return (LogicProjects.UpdateProject(value)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };

            List<string> ErrorList = new List<string>();
            //if the code reached this part - the Project is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };
        }
        //sum hours that user worked on spesipic project on specipic month
        [HttpGet]
        [Route("api/Projects/SumHoursUserWorkedProjectOnSpecipicMonth")]
        public HttpResponseMessage SumHoursUserWorkedProjectOnSpecipicMonth(int idProject, int idUser, int? month)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicProjects.SumHoursUserWorkedProjectOnSpecipicMonth(idProject, idUser, month));
        }
        //return the hours that users worked on that.
        [HttpGet]
        [Route("api/Projects/GetHoursThatWorkedOnProject")]
        public HttpResponseMessage GetHoursThatWorkedOnProject(int idProject)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicProjects.GetHoursThatWorkedOnProject(idProject));
        }
        //get dictionary of days and the hours that worked in this day on any project
        [HttpGet]
        [Route("api/Projects/GetHoursWorkedOnProjectByDays")]
        public HttpResponseMessage GetHoursWorkedOnProjectByDays(int idProject, int month)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Dictionary<string, double>>(LogicProjects.GetHoursWorkedOnProjectByDays(idProject, month), new JsonMediaTypeFormatter())
            };
        }
        //return all users and graf about projects:dictionary of users and how many hours precent they worked
        [HttpGet]
        [Route("api/Projects/GetUsersAndGrafOfProject")]
        public HttpResponseMessage GetUsersAndGrafOfProject(string nameProject)
        {
            List<User> users = LogicUsers.GetUsersByNameOfProject(nameProject);
            Dictionary<UserProject, double> myGraf = LogicProjects.GetUsersAndHoursThatWorkedOnProject(LogicProjects.GetProjectByNameProject(nameProject).IdProject);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<MyClass>(new MyClass() { Users = users, MyGraf = myGraf }, new JsonMediaTypeFormatter())
            };
        }
        //return all the users that didnt finish all the hours
        [HttpGet]
        [Route("api/Projects/GetUsersThatNotFinishAllTheHours")]
        public HttpResponseMessage GetUsersAndGrafOfProjmect(string nameProject)
        {
            List<User> usersNotFinishProject=new List<User>();
            Project myProject = LogicProjects.GetProjectByNameProject(nameProject);
            Dictionary<UserProject, double> UsersAndHoursWorkedOnProject;
            if (myProject.Active)
            {
                UsersAndHoursWorkedOnProject=LogicProjects.GetUsersAndHoursThatWorkedOnProject(myProject.IdProject);
                foreach (var item in UsersAndHoursWorkedOnProject)
                {
                    if (item.Value != 100)
                        usersNotFinishProject.Add(LogicUsers.GetUserByIdUser(item.Key.IdUser));
                }
            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(usersNotFinishProject, new JsonMediaTypeFormatter())
            };
        }
        //graf of status hours that updated by users on all their projects by getting the teamLeader
        [Route("api/Projects/GetUsersAndHoursThatUsersWorkedUnderTheirTeamLeader")]
        public HttpResponseMessage GetUsersAndHoursThatUsersWorkedUnderTheirTeamLeader(int idTeamLeader)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Dictionary<User,ObjectOfHours>>(LogicProjects.GetUsersAndHoursThatUsersWorkedUnderTheirTeamLeader(idTeamLeader), new JsonMediaTypeFormatter())
            };
        }
        //return all users under specipic teamLeader devided to projects
        [HttpGet]
        [Route("api/Projects/GetUsersDevidedToProjectsUnderTeamLeader")]
        public static HttpResponseMessage GetUsersDevidedToProjectsUnderTeamLeader(int idTeamLeader)
        {
            Dictionary<Project, List<User>> allProjectsWithThemUsersUnderTeamLeader = new Dictionary<Project, List<User>>();
            List<Project> allProjectsUnderTeamLeader = LogicProjects.GetProjectsUnderTeamLeader(idTeamLeader);
            foreach (var item in allProjectsUnderTeamLeader)
            {
                allProjectsWithThemUsersUnderTeamLeader.Add(item, LogicUsers.GetUsersOfProject(item.IdProject));
            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Dictionary<Project, List<User>>>(allProjectsWithThemUsersUnderTeamLeader, new JsonMediaTypeFormatter())
            };
        }
        //get all data on projects
        [HttpGet]
        [Route("api/Projects/GetAllDataOnProject")]
        public static HttpResponseMessage GetAllDataOnProject(int idProject)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Dictionary<ProjectObject, List<UserObject>>>(LogicProjects.GetAllDataOnProject(idProject), new JsonMediaTypeFormatter())
            };
        }

        [HttpGet]
        [Route("api/Projects/GetProjectByName")]
        public static HttpResponseMessage GetProjectByName(string nameProject)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Project>(LogicProjects.GetProjectByNameProject(nameProject), new JsonMediaTypeFormatter())
            };
        }
    }


}

