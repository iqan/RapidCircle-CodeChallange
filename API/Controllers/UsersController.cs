using Data.Repository;
using Models;
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
            var result = _repository.AddUser(user);
            return CreatedAtRoute("DefaultApi", new { controller = "users", id = user.Id }, user);
        }

        public Users GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public Users GetUserByUserId(string id)
        {
            return _repository.GetUserByUserId(id);
        }
    }
}
