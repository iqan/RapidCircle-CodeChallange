using Data.Repository;
using Models;
using System.Collections.Generic;
using System;

namespace API.BusinessLogic
{
    public class Mapper
    {
        private readonly IUsersRepository _repository;

        public Mapper(IUsersRepository repository)
        {
            _repository = repository;
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
            var user = _repository.GetUserByUserId(userId);
            return user!=null?user.Name:"User";
        }
    }
}