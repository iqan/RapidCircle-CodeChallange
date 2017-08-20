using Data.DataContext;
using System;
using System.Collections.Generic;
using Models;
using System.Linq;

namespace Data.Repository.EF
{
    public class PostsRepository : IPostsRepository
    {
        private readonly EFContext _context;

        public PostsRepository(EFContext context)
        {
            _context = context;
        }

        public int AddPost(Posts post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int postId)
        {
            throw new NotImplementedException();
        }

        public Posts GetPostById(int postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Posts> GetPostsByUserId(string userId)
        {
            return _context.Posts.Where(p => p.UserId.Equals(userId));
        }

        public int UpdatePost(Posts post)
        {
            throw new NotImplementedException();
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
