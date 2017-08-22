using System;
using System.Collections.Generic;
using Models;
using Data.DataContext;
using System.Linq;

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
            try
            {
                _context.Friends.Add(Friend);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log error
            }
            return 0;
        }

        public void DeleteFriend(int userId, int FriendId)
        {
            // TODO implement
        }

        public IEnumerable<Friends> GetAllFriends()
        {
            return _context.Friends;
        }

        public IEnumerable<Friends> GetFriendsById(string userId)
        {
            return _context.Friends.Where(f => f.UserId == userId);
        }

        public int UpdateFriend(Friends Friend)
        {
            // TODO implement
            return 1;
        }

        #region Dispose Methods
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion    }
    }
}
