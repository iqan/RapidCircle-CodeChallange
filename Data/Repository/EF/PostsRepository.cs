using Data.DataContext;
using System;
using System.Collections.Generic;
using Models;

namespace Data.Repository.EF
{
    public class PostsRepository : IPostsRepository
    {
        private readonly EFContext _context;

        public PostsRepository(EFContext context)
        {
            _context = context;
        }

        public int AddPost(Models.Posts post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int postId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Posts GetPostById(int postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Posts> GetPostsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public int UpdatePost(Models.Posts post)
        {
            throw new NotImplementedException();
        }
    }
}
