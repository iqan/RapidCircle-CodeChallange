using Data.DataContext;
using System;
using System.Collections.Generic;

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

        public IEnumerable<Models.Posts> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Posts> GetPostsById(string userId)
        {
            throw new NotImplementedException();
        }

        public int UpdatePost(Models.Posts post)
        {
            throw new NotImplementedException();
        }
    }
}
