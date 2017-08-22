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
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostsController : ApiController
    {
        private readonly IPostsRepository _repository;
        private readonly Mapper _mapper;
        private readonly UserClaims _userClaims;

        public PostsController(IPostsRepository repository, Mapper mapper, UserClaims userClaims)
        {
            _repository = repository;
            _mapper = mapper;
            _userClaims = userClaims;
        }
        
        // GET: api/Posts
        public IEnumerable<ViewModels.Posts> Get()
        {
            var userId = _userClaims.GetUserId();
            var posts = _repository.GetPostsForUserId(userId);
            var postList = posts.Select(item => _mapper.MapToPostsViewModel(item));
            return postList;
        }

        // GET: api/Posts/5
        public Posts Get(int id)
        {
            return _repository.GetPostById(id);
        }

        // POST: api/Posts
        public IHttpActionResult Post([FromBody]Posts post)
        {
            var userId = _userClaims.GetUserId();
            post.UserId = userId;
            var result = _repository.AddPost(post);
            return CreatedAtRoute("DefaultApi", new { controller = "posts", id = post.Id }, post);
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
