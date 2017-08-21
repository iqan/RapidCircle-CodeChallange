using System;
using System.Collections.Generic;
using Models;
using Data.DataContext;
using System.Linq;

namespace Data.Repository.EF
{
    public class UsersRepository : IUsersRepository
    {
        private readonly EFContext _context;

        public UsersRepository(EFContext context)
        {
            _context = context;
        }

        public int AddUser(Users user)
        {
            _context.Users.Add(user);
            var result = _context.SaveChanges();
            return result;
        }

        public void DeleteUser(int userId)
        {
            // TODO implement
        }

        public Users GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public Users GetUserByUserId(string userId)
        {
            return _context.Users.FirstOrDefault(p => p.UserId.Equals(userId));
        }

        public IEnumerable<Users> GetUsers()
        {
            return _context.Users;
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
