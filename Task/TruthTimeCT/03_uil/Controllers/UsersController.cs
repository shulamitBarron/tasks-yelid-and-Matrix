using _01_BOL;
using _01_BOL.HelpModels;
using _02_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _03_uil.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(LogicUsers.GetAllUsers(), new JsonMediaTypeFormatter())
            };
        }

        // GET: api/Users/5
        public HttpResponseMessage Get(int id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<String>(LogicUsers.GetUserName(id), new JsonMediaTypeFormatter())
            };
        }

        // POST: api/Users
        public HttpResponseMessage Post([FromBody]User value)
        {
            if (ModelState.IsValid)
            {
                return (LogicUsers.AddUser(value)) ?
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

        // PUT: api/Users/5 it also good to connect user to the new TeamLeader
        public HttpResponseMessage Put([FromBody]User value)
        {

            if (ModelState.IsValid)
            {
                return (LogicUsers.UpdateUser(value)) ?
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

        // DELETE: api/Users/5
        public HttpResponseMessage Delete(int id)
        {
            return (LogicUsers.RemoveUser(id)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }
        //get users under the direction of team leader
        [HttpGet]
        [Route("api/Users/GetAllUsersUnderTheDirectionOfTheTeamLeader")]
        public HttpResponseMessage GetAllUsersUnderTheDirectionOfTheTeamLeader(int idTeamLeader)
        {
           
            return Request.CreateResponse(HttpStatusCode.OK, LogicUsers.GetAllUsersUnderTeamLeader(idTeamLeader));
        }


        [HttpGet]
        [Route("api/Users/GetAllTeamLeaders")]
        public HttpResponseMessage GetAllTeamLeaders()
        {

            return Request.CreateResponse(HttpStatusCode.OK, LogicUsers.GetAllTeamLeader());
        }

        //login to angular
        [HttpPost]
        [Route("api/Users/Login")]
        public HttpResponseMessage Login([FromBody]UserHelp value)
        {

            if (ModelState.IsValid)
            {
                User user = LogicUsers.GetAllUsers().FirstOrDefault(p => p.UserName == value.UserName && p.Password == value.Password);
                return (user != null) ?
              new HttpResponseMessage(HttpStatusCode.OK)
              {
                  Content = new ObjectContent<User>(user, new JsonMediaTypeFormatter())
              }:
              new HttpResponseMessage(HttpStatusCode.OK)
              {
                  Content = new ObjectContent<String>("You aren't singed", new JsonMediaTypeFormatter())
              };

            }
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
    }
}
