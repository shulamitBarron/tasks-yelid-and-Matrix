using _01_BOL;
using _02_BLL;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace _03_uil.Controllers
{
    public class StatusUsersController : ApiController
    {
        // GET: api/StatusUsers
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<StatusUser>>(LogicStatusUsers.GetAllStatusUsers(), new JsonMediaTypeFormatter())
            };
        }

        // GET: api/StatusUsers/5
        public HttpResponseMessage Get(int id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<String>(LogicStatusUsers.GetStatusName(id), new JsonMediaTypeFormatter())
            };
        }
    }


}

