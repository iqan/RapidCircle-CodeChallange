using Data.Repository;
using Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace API.BusinessLogic
{
    public class Mapper
    {
        private readonly IUsersRepository _userRepository;

        public Mapper(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ViewModels.Posts MapToPostsViewModel(Posts post)
        {
            var pvm = new ViewModels.Posts
            {
                Id = post.Id,
                DatePosted = post.DatePosted,
                Text = post.Text,
                UserId = post.UserId,
                UserName = GetUserName(post.UserId)
            };
            return pvm;
        }

        private string GetUserName(string userId)
        {
            var user = _userRepository.GetUserByUserId(userId);
            return user!=null?user.Name:"User";
        }

        public IEnumerable<Users> GetUsersByIds(IEnumerable<string> userIds)
        {
            return _userRepository.GetUsers().Where(u => userIds.Contains(u.UserId));
        }

        internal IEnumerable<ViewModels.Friends> MapToFriendsViewModel(IEnumerable<string> friendsIds)
        {
            var allUsers = _userRepository.GetUsers();
            return _userRepository.GetUsers().Where(u=>friendsIds.Contains(u.UserId))
                .Select(u=>new ViewModels.Friends { key = u.Id, text = u.Name });
        }
    }
}