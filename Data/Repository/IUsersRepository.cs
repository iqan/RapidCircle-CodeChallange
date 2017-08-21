using System;
using System.Collections.Generic;
using Models;

namespace Data.Repository
{
    public interface IUsersRepository : IDisposable
    {
        IEnumerable<Users> GetUsers();
        Users GetUserById(int userId);
        int AddUser(Users user);
        void DeleteUser(int userId);
        Users GetUserByUserId(string userId);
    }
}
