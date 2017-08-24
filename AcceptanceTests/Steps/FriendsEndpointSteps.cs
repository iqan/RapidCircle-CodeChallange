using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public sealed class FriendsEndpointSteps
    {
        [Given(@"I have logged in")]
        public void GivenIHaveLoggedIn()
        {
            // Get access token from Azure Ad b2c auth service

            // store it in memory
        }

        [Given(@"I have user id to add")]
        public void GivenIHaveUserIdToAdd()
        {
            // get a random user id that is not in friend list

            // save user id to memory
        }

        [When(@"I request api to add user")]
        public void WhenIRequestApiToAddUser()
        {
            // call api endpoint - 
            // url = https://<apiBaseUrl>/api/friends
            // header = authorization: bearer <accessToken>, contentType: application/json
            // method = POST
            // data = { userId: "someid1", friendId: "someid2"}
            // get response and save it to memory
        }

        [Then(@"user should be added to friend list")]
        public void ThenUserShouldBeAddedToFriendList()
        {
            // validate response
            Assert.Pass();
        }

    }
}
