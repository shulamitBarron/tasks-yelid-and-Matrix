using MemoryGame.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MemoryGame

{

    public class UserController : ApiController
    {

        [Route("api/login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                lock (Global.UserList)
                {
                    if (Global.UserList.Any(u => u.UserName == user.UserName))
                    {
                        return BadRequest("there is this user name yet");
                    }
                    Global.UserList.Add(user);
                }
                return Ok();
            }
             return Content(HttpStatusCode.BadRequest,ModelState.Values.Select(e => e.Errors).ToList());

        }
        [Route("api/getUsersWaitToPartner")]
        [HttpGet]
        public IHttpActionResult GetUsersWaitToPartner()
        {
            return Ok(Global.UserList.Where(u => u.PartnerName == null).Select(p => new { p.UserName, p.Age }));
        }
        [Route("api/getUserDetails/{userName}")]
        [HttpGet]
        public IHttpActionResult GetUserDetails(string userName)
        {
            return Ok(Global.UserList.FirstOrDefault(u => u.UserName == userName));
        }

        [Route("api/ChoosingPartner/{userName}")]
        [HttpPut]
        public IHttpActionResult ChoosingPartner(string userName, [FromBody]User partnerUser)
        {
            lock (Global.UserList)
            {

                var user = Global.UserList.FirstOrDefault(u => u.UserName == userName);
                var partner = Global.UserList.FirstOrDefault(u => u.UserName == partnerUser.UserName);
                if (user.PartnerName == null)
                    if (partner.PartnerName == null)
                    {
                        user.PartnerName = partnerUser.UserName;
                        partner.PartnerName = userName;
                        Game g = new Game()
                        {
                            Player1 = user,
                            Player2 = partner,
                            CurrentTurn = user.UserName,
                            CardArray = { { "1",null}, { "2", null}, { "3", null},
                                      { "4",null}, { "5",null}, { "6",null},
                                      { "7",null}, { "8",null}, { "9",null}}

                        };

                        Global.GameList.Add(g);

                        return Ok();

                    }
                    else
                    {
                        return BadRequest("the partner catch yet");
                    }
                else return BadRequest("you has partner yet");
            }
        }
    }
}
