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
        private readonly IFriendsRepository _friendsRepository;
        private readonly UserClaims _userClaims;
        private readonly Mapper _mapper;

        public FriendsController(IFriendsRepository friendsRepository, Mapper mapper, UserClaims userClaims)
        {
            _friendsRepository = friendsRepository;
            _userClaims = userClaims;
            _mapper = mapper;
        }

        // GET: api/Friends
        public IEnumerable<ViewModels.Friends> Get()
        {
            var userId = _userClaims.GetUserId();
            var friendsIds = _friendsRepository.GetFriendsById(userId).Select(f=>f.FriendId);
            return _mapper.MapToFriendsViewModel(friendsIds);
        }

        // POST: api/Friends
        public IHttpActionResult Post([FromBody]Friends friend)
        {
            if (string.IsNullOrEmpty(friend.UserId))
            {
                friend.UserId = _userClaims.GetUserId();
            }
            var result = _friendsRepository.AddFriend(friend);
            return CreatedAtRoute("DefaultApi", new { controller = "friends", id = friend.Id }, friend);
        }
    }
}
