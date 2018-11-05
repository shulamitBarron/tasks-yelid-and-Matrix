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
    public class UsersProjectsController : ApiController
    {
        // GET: api/UserProjects
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<UserProject>>(LogicUserProject.GetAllUserProject(), new JsonMediaTypeFormatter())
            };
        }

        // GET: api/UserProject/5
        public HttpResponseMessage Get(int id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<String>(LogicUserProject.GetHoursProjectUser(id), new JsonMediaTypeFormatter())
            };
        }

        // POST: api/UserProject
        public HttpResponseMessage Post([FromBody]UserProject value)
        {
            if (ModelState.IsValid)
            {
                return (LogicUserProject.AddUserProject(value)) ?
                   new HttpResponseMessage(HttpStatusCode.Created) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                   };
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };

        }

        // PUT: api/Users/5
        public HttpResponseMessage Put([FromBody]UserProject value)
        {

            if (ModelState.IsValid)
            {
                return (LogicUserProject.UpdateUserProject(value)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };
        }

        // DELETE: api/UserProject/5
        public HttpResponseMessage Delete(int id)
        {
            return (LogicUserProject.RemoveUserProject(id)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }
        //update hours to userProject
        [HttpPut]
        [Route("api/UserProjects/UpdateHoursToUserProject/{hoursProjectUser}")]
        public HttpResponseMessage UpdateHoursToUserProject([FromBody]int idUserProject, int hoursProjectUser)
        {
            UserProject userProject = LogicUserProject.GetUserProjectById(idUserProject);
            userProject.HoursProjectUser = hoursProjectUser;
            if (ModelState.IsValid)
            {
                return (LogicUserProject.UpdateUserProject(userProject)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };

        }
        //return all project under specipic user
        [HttpGet]
        [Route("api/UserProjects/AllProjectOfSpecipicUser")]
        public HttpResponseMessage AllProjectOfSpecipicUser(int idUser)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Project>>(LogicUserProject.AllProjectOfSpecipicUser(idUser), new JsonMediaTypeFormatter())
            };
        }
        //return x days and y hours that user worked on specipic project
        [HttpGet]
        [Route("api/UserProjects/GetDaysAndHoursUserWorkedOnProject/{idProject}/{idUser}")]
        public HttpResponseMessage GetDaysAndHoursUserWorkedOnProject(int idProject, int idUser)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<HoursOfUserProjectByDays>>(LogicUserProject.GetDaysAndHoursUserWorkedOnProject(idProject, idUser), new JsonMediaTypeFormatter())
            };

        }
        //return all names of users and userprojects under teamleader
        [HttpGet]
        [Route("api/UserProjects/GetAllUserProjectUnderTeamLeaderWithNames/{idTeamLeader}")]
        public HttpResponseMessage GetAllUserProjectUnderTeamLeaderWithNames(int idTeamLeader)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<UserProjectHelp>>(LogicUserProject.GetAllUserProjectUnderTeamLeaderWithNames(idTeamLeader), new JsonMediaTypeFormatter())
            };

        }
        [HttpPut]
        [Route("api/UserProjects/SetAllUsersProjects")]
        public HttpResponseMessage SetAllUsersProjects([FromBody] List<UserProject> userProjectList)
        {
            return (LogicUserProject.SetAllUsersProjects(userProjectList)) ?
                new HttpResponseMessage(HttpStatusCode.OK) :
                new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                };
        }

    }
}

