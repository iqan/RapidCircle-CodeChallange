using System;
using System.Collections.Generic;

namespace Data.Repository
{
    public interface IPostsRepository : IDisposable
    {
        IEnumerable<Models.Posts> GetAllPosts();
        IEnumerable<Models.Posts> GetPostsById(string userId);
        int AddPost(Models.Posts post);
        int UpdatePost(Models.Posts post);
        void DeletePost(int postId);
    }
}
