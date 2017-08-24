using NUnit.Framework;
using Moq;
using Data.Repository;
using Models;
using API.Controllers;
using API.BusinessLogic;
using System.Web;
using System.Web.Http.Results;
using System;
using Vm = API.ViewModels;

namespace UnitTests.API.Controllers
{
    [TestFixture]
    public class PostsControllerTests
    {
        [Test]
        public void Post_Method_Should_Return_201_On_Success()
        {
            var mockUserClaims = new Mock<UserClaims>();
            var mockRepo = new Mock<IPostsRepository>();
            var mockUserRepo = new Mock<IUsersRepository>();
            var mapper = new Mapper(mockUserRepo.Object);

            // setup
            var datePosted = DateTime.Now;

            var user = new Users
            {
                Id =1,
                UserId = "id",
                Name = "name"
            };

            var post = new Posts
            {
                DatePosted = datePosted,
                Text = "qwe",
                UserId = user.UserId
            };

            var postsvm = new Vm.Posts();

            mockUserClaims.Setup(s=>s.GetUserId()).Returns(user.UserId);
            mockRepo.Setup(s => s.AddPost(It.IsAny<Posts>())).Returns(1);
            mockUserRepo.Setup(s=>s.GetUserByUserId(It.IsAny<string>())).Returns(user);

            var postsController = new PostsController(mockRepo.Object, mapper, mockUserClaims.Object);

            var result = postsController.Post(post);

            Assert.IsInstanceOf<CreatedAtRouteNegotiatedContentResult<Vm.Posts>>(result);

            mockUserClaims.Verify(v => v.GetUserId(), Times.Once);
            mockRepo.Verify(v => v.AddPost(It.Is<Posts>(i=>i==post)), Times.Once);
            mockUserRepo.Verify(v => v.GetUserByUserId(It.Is<string>(i => i == user.UserId))
                , Times.Once);
        }
    }
}
