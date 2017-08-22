using NUnit.Framework;
using Moq;
using Data.Repository;
using Models;
using API.Controllers;
using API.BusinessLogic;
using System.Web;
using System.Web.Http.Results;
using System;

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
            var mockMapper = new Mock<Mapper>(null);

            // setup
            var userId = "userId123";
            var datePosted = DateTime.Now;
            
            mockUserClaims.Setup(s=>s.GetUserId()).Returns(userId);
            mockRepo.Setup(s => s.AddPost(It.IsAny<Posts>())).Returns(1);

            var post = new Posts {
                DatePosted = datePosted,
                Text = "qwe",
                UserId = userId
            };

            var postsController = new PostsController(mockRepo.Object, mockMapper.Object, mockUserClaims.Object);

            var result = postsController.Post(post);

            Assert.IsInstanceOf<CreatedAtRouteNegotiatedContentResult<Posts>>(result);

            mockUserClaims.Verify(v => v.GetUserId(), Times.Once);
            mockRepo.Verify(v => v.AddPost(It.Is<Posts>(i=>i==post)), Times.Once);
        }
    }
}
