using System;
using System.Collections.Generic;
using Models;

namespace Data.Repository
{
    public interface IPostsRepository : IDisposable
    {
        IEnumerable<Models.Posts> GetPostsByUserId(string userId);
        Posts GetPostById(int postId);
        int AddPost(Models.Posts post);
        int UpdatePost(Models.Posts post);
        void DeletePost(int postId);
    }
}
