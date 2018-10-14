using MemoryGame.Models;
using System.Linq;
using System.Web.Http;

namespace MemoryName.Controllers
{
    public class GameController : ApiController
    {
        [Route("api/getGame/{userName}")]
        [HttpGet]
        public IHttpActionResult GetGame(string userName)
        {
            var currentGame = Global.GameList.FirstOrDefault(g => g.Player1.UserName == userName|| g.Player2.UserName == userName);
            return Ok(new { currentGame.CardArray, currentGame.CurrentTurn });
        }
        /// <summary>
        /// put- get one param from url and other from body.
        /// for update turn sent user name and list cards choosen -two card
        /// and function return name turn now and param boolean if now it end game 
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="listChosen">{firstCard},{secondCard}</param>
        /// <returns></returns>
        [Route("api/updateTurn/{userName}")]
        [HttpPut]
        public IHttpActionResult UpdateTurn(string userName, [FromBody]string[] listChosen)
        {

            var currentGame = Global.GameList.FirstOrDefault(g => g.CurrentTurn == userName);
            if (currentGame == null)
                return BadRequest("The turn not  yours");
            lock (currentGame)
            {
               

                if (listChosen[0] == listChosen[1])
                {

                    Global.UserList.FirstOrDefault(p => p.UserName == userName).Score++;
                    currentGame.CardArray[listChosen[0]] = userName;
                   if( !currentGame.CardArray.Any(c => c.Value == null))
                    {
                        return Ok(new {player= EndGame(currentGame) ,end= true});
                    }
                }
                currentGame.CurrentTurn = currentGame.CurrentTurn == currentGame.Player1.UserName ? currentGame.Player2.UserName : currentGame.Player1.UserName;

            }
            return Ok(new { player = currentGame.CurrentTurn, end = false });
        }

        private string EndGame(Game currentGame)
        {

            var p1Cards = currentGame.CardArray.Count(c => c.Value == currentGame.Player1.UserName);
            var p2Cards = currentGame.CardArray.Count(c => c.Value == currentGame.Player2.UserName);
            if (p1Cards > p2Cards)
            {
              return  currentGame.Player1.UserName;
            }
            else {
              return  currentGame.Player2.UserName;
            }
               

        }
    }
}
