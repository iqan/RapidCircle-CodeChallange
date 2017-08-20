using Data.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPostsRepository _repository;

        public PostsController(IPostsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Posts
        public IEnumerable<Posts> Get()
        {
            var userId = "";
            return _repository.GetPostsByUserId(userId);
        }

        // GET: api/Posts/5
        public Posts Get(int postId)
        {
            return _repository.GetPostById(postId);
        }

        // POST: api/Posts
        public void Post([FromBody]Posts post)
        {
            var result = _repository.AddPost(post);
        }

        // PUT: api/Posts/5
        public void Put(int postId, [FromBody]Posts post)
        {
            var result = _repository.UpdatePost(post);
        }

        // DELETE: api/Posts/5
        public void Delete(int postId)
        {
            _repository.DeletePost(postId);
        }
    }
}
