using API.BusinessLogic;
using Data.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FriendsController : ApiController
    {
        private readonly IFriendsRepository _repository;
        private readonly UserClaims _userClaims;

        public FriendsController(IFriendsRepository repository, UserClaims userClaims)
        {
            _repository = repository;
            _userClaims = userClaims;
        }

        // GET: api/Friends/5
        public IEnumerable<Friends> Get(string id)
        {
            return _repository.GetFriendsById(id);
        }

        // POST: api/Friends
        public IHttpActionResult Post([FromBody]Friends friend)
        {
            var result = _repository.AddFriend(friend);
            return CreatedAtRoute("DefaultApi", new { controller = "friends", id = friend.Id }, friend);
        }

        // DELETE: api/Friends/5
        public void Delete(int id)
        {
        }
    }
}
