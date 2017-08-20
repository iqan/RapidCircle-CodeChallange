using System;
using System.Collections.Generic;
using Models;
using Data.DataContext;

namespace Data.Repository.EF
{
    public class FriendsRepository : IFriendsRepository
    {
        private readonly EFContext _context;

        public FriendsRepository(EFContext context)
        {
            _context = context;
        }
        public int AddFriend(Friends Friend)
        {
            throw new NotImplementedException();
        }

        public void DeleteFriend(int userId, int FriendId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friends> GetAllFriends()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friends> GetFriendsById(string userId)
        {
            throw new NotImplementedException();
        }

        public int UpdateFriend(Friends Friend)
        {
            throw new NotImplementedException();
        }
    }
}
