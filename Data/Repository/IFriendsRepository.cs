using System;
using System.Collections.Generic;

namespace Data.Repository
{
    public interface IFriendsRepository : IDisposable
    {
        IEnumerable<Models.Friends> GetAllFriends();
        IEnumerable<Models.Friends> GetFriendsById(string userId);
        int AddFriend(Models.Friends Friend);
        int UpdateFriend(Models.Friends Friend);
        void DeleteFriend(int userId, int FriendId);
    }
}
