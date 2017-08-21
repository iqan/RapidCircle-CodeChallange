using Data.Repository;
using Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private readonly IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Post([FromBody]Users user)
        {
            try
            {
                var result = _repository.AddUser(user);
                return CreatedAtRoute("DefaultApi", new { controller = "users", id = user.Id }, user);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("","An error occurred. Error: "+ ex.Message);
                return BadRequest(ModelState);
            }
        }

        public Users GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public Users Get(string id)
        {
            return _repository.GetUserByUserId(id);
        }

        public IEnumerable<Users> Get()
        {
            return _repository.GetUsers();
        }
    }
}
