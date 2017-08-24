Feature: FriendsEndpoint
	In order to add a friend
	As a user
	I want to be able to add user to friend list

@addFriend
Scenario: Add a new friend
	Given I have logged in
	And I have user id to add
	When I request api to add user
	Then user should be added to friend list
