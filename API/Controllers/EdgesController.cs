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

            var usersFriends = allFriends.Where(f => f.UserId == userId).ToList();
            var userFriendsIds = usersFriends.Select(f => f.FriendId);

            foreach (var item in usersFriends)
            {
                var friendsOfFriends = allFriends.Where(f => f.UserId == item.FriendId);

                foreach (var friend in friendsOfFriends)
                {
                    if (userFriendsIds.Contains(friend.FriendId))
                    {
                        var fromId = allUser.FirstOrDefault(u=>u.UserId == item.FriendId).Id;
                        var toId = allUser.FirstOrDefault(u => u.UserId == friend.FriendId).Id;

                        edges.Add(new Edges { from = fromId, to = toId });
                    }
                }
            }

            return edges;
        }
    }
}
