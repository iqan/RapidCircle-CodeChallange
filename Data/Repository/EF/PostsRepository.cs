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
            var result = _context.Posts.Add(post);
            _context.SaveChanges();
            return result.Id;
        }

        public void DeletePost(int postId)
        {
            // TODO implement
        }

        public Posts GetPostById(int postId)
        {
            return _context.Posts.Find(postId);
        }

        public IEnumerable<Posts> GetPostsForUserId(string userId)
        {
            var friendsIds = _context.Friends.Where(f => f.UserId == userId).Select(f=>f.FriendId);
            return _context.Posts.Where(p => p.UserId.Equals(userId) || friendsIds.Contains(p.UserId));
        }

        public int UpdatePost(Posts post)
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
