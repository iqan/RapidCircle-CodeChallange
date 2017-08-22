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
    public class SuggestionController : ApiController
    {
        private readonly IFriendsRepository _friendsRepository;
        private readonly IUsersRepository _userRepository;
        private readonly UserClaims _userClaims;

        public SuggestionController(IFriendsRepository friendsRepository, UserClaims userClaims, IUsersRepository userRepository)
        {
            _friendsRepository = friendsRepository;
            _userClaims = userClaims;
            _userRepository = userRepository;
        }

        // GET: api/Suggestion/
        public IEnumerable<Users> Get()
        {
            // TODO refactor / extract method
            var suggestions = new List<Users>();

            var userId = _userClaims.GetUserId();

            var friendsIds = _friendsRepository.GetFriendsById(userId).Select(f => f.FriendId);

            var users = _userRepository.GetUsers();
            var allFriends = _friendsRepository.GetAllFriends();

            // if user has no friend, suggest random 3
            if (friendsIds.Count() == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    var random = new Random(i);
                    var randomId = random.Next(1, users.Count());
                    suggestions.Add(users.FirstOrDefault(u => u.Id == randomId));
                }
                return suggestions;
            }

            var friends = Relations.GetFriendsOfFriendsIds(friendsIds, allFriends);

            foreach (var item in friends)
            {
                if (friendsIds.Contains(item))
                {
                    continue;
                }
                suggestions.Add(users.FirstOrDefault(u => u.UserId == item));
            }

            return suggestions;
        }
    }
}
