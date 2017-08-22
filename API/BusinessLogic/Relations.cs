using Models;
using System.Collections.Generic;
using System.Linq;

namespace API.BusinessLogic
{
    public class Relations
    {
        public static List<string> GetFriendsOfFriendsIds(IEnumerable<string> friendsIds, IEnumerable<Friends> allFriends)
        {
            var friends = new List<string>();
            foreach (var item in friendsIds)
            {
                friends.AddRange(allFriends.Where(f => f.UserId == item).Select(f => f.FriendId));
            };

            friends = friends.Distinct().ToList();
            return friends;
        }
    }
}