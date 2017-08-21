using API.BusinessLogic;
using Data.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostsController : ApiController
    {
        private readonly IPostsRepository _repository;

        public PostsController(IPostsRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        // GET: api/Posts
        public IEnumerable<Posts> Get()
        {
            var userId = UserClaims.GetUserId();
            return _repository.GetPostsByUserId(userId);
        }

        // GET: api/Posts/5
        public Posts Get(int id)
        {
            return _repository.GetPostById(id);
        }

        // POST: api/Posts
        public void Post([FromBody]Posts post)
        {
            var result = _repository.AddPost(post);
        }

        // PUT: api/Posts/5
        public void Put(int id, [FromBody]Posts post)
        {
            var result = _repository.UpdatePost(post);
        }

        // DELETE: api/Posts/5
        public void Delete(int id)
        {
            _repository.DeletePost(id);
        }
    }
}
