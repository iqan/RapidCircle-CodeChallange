using API.BusinessLogic;
using API.ViewModels;
using Data.Repository;
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
    public class EdgesController : ApiController
    {
        private readonly IFriendsRepository _friendsRepository;
        private readonly IUsersRepository _userRepository;
        private readonly UserClaims _userClaims;

        public EdgesController(IFriendsRepository friendsRepository, UserClaims userClaims, IUsersRepository userRepository)
        {
            _friendsRepository = friendsRepository;
            _userClaims = userClaims;
            _userRepository = userRepository;
        }

        // GET: api/Edges
        public IEnumerable<Edges> Get()
        {
            var edges = new List<Edges>();
            var userId = _userClaims.GetUserId();

            var allUser = _userRepository.GetUsers();
            var allFriends = _friendsRepository.GetAllFriends();

            var usersFriends = allFriends.Where(f => f.UserId == userId);

            foreach (var item in usersFriends)
            {
                var friendsOfFriends = allFriends.Where(f => f.UserId == item.UserId);

                foreach (var friend in friendsOfFriends)
                {
                    if (friend.FriendId == userId)
                    {
                        edges.Add(new Edges { from = item.Id, to = friend.Id });
                    }
                }
            }

            return edges;
        }
    }
}
