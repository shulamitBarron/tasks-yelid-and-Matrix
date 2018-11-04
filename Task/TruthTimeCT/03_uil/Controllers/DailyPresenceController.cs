using System;
using System.Collections.Generic;
using _01_BOL;
using _02_BLL;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using _01_BOL.HelpDepartment;

namespace _03_uil.Controllers
{
    public class DailyPresenceController : ApiController
    {
        // GET: api/DailyPresence
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<DailyPresence>>(LogicDailyPresence.GetAllDailyPresence(), new JsonMediaTypeFormatter())
            };
        }

        // GET: api/Users/5
        //public HttpResponseMessage Get(int id)
        //{
        //    return new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ObjectContent<String>(LogicDailyPresence.(id), new JsonMediaTypeFormatter())
        //    };
        //}

        // POST: api/Users
        public HttpResponseMessage Post([FromBody]DailyPresence value)
        {
            if (ModelState.IsValid)
            {
                return (LogicDailyPresence.AddDailyPresence(value)) ?
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
        public HttpResponseMessage Put([FromBody]DailyPresence value)
        {

            if (ModelState.IsValid)
            {
                return (LogicDailyPresence.UpdateDailyPresence(value)) ?
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
            return (LogicDailyPresence.RemoveDailyPresence(id)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }
        //get all dailypresence of user under teamLeader

        [HttpGet]
        [Route("api/DailyPresence/GetDailyPresenceOfUserOfTheTeamLeader")]
        public HttpResponseMessage GetDailyPresenceOfUserOfTheTeamLeader(int idTeamLeader)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicDailyPresence.GetDailyPresenceOfUserOfTheTeamLeader(idTeamLeader));
        }
        //get StatusHours of all dailypresence of users under teamLeader
        [HttpGet]
        [Route("api/DailyPresence/GetStatusHoursUnderTheDirectionOfTheTeamLeader")]
        public HttpResponseMessage GetStatusHoursUnderTheDirectionOfTheTeamLeader(int idTeamLeader, int month)
        {
            List<DailyPresence> dailyPresence = LogicDailyPresence.GetDailyPresenceOfUserOfTheTeamLeader(idTeamLeader);
            double statusHours = 0;
            foreach (DailyPresence dailyPresenceItem in dailyPresence)
            {
                if (dailyPresenceItem.StartDatePresence.Month == month)
                {
                    statusHours += (dailyPresenceItem.EndDatePresence - dailyPresenceItem.StartDatePresence).TotalHours;
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, statusHours);
        }
        [HttpGet]
        [Route("api/DailyPresence/GetNamesProjectsAndIdUPTodayForUser/{idUser}")]
        public HttpResponseMessage GetNamesProjectsAndIdUPTodayForUser(int idUser)
        {
            List<UserProjectHelp> NamesProjectsAndIdUPToday = LogicDailyPresence.GetNamesProjectsAndIdUPTodayForUser(idUser);
            return Request.CreateResponse(HttpStatusCode.OK, NamesProjectsAndIdUPToday);
        }
    }
}