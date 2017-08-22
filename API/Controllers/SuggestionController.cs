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
            var friends = new List<string>();
            var suggestions = new List<Users>();

            var userId = _userClaims.GetUserId();

            var friendsIds = _friendsRepository.GetFriendsById(userId).Select(f => f.FriendId);
            var users = _userRepository.GetUsers();

            foreach (var item in friendsIds)
            {
                friends.AddRange(_friendsRepository.GetFriendsById(item).Select(f => f.FriendId));
            };

            friends = friends.Distinct().ToList();

            foreach (var item in friends)
            {
                suggestions.Add(_userRepository.GetUserByUserId(item));
            }

            return suggestions;
        }
    }
}
