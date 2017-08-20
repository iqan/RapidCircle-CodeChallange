# RapidCircle-CodeChallange
RapidCircle-CodeChallange

## Requirements

### Part 1: Create friend relations
1. Retrieve the IDs of people following or followed by a given handle. Let’s call the list L.
2. for each person P in L, get a list of people followed by the corresponding person, e.g. Friend(P)
3. for each X in Friend(P): if X is Friend(P) and P in our list L, create an edge [P,X] and add it to the graph.
5. Display the resultant graph on a webpage using AngularJS consuming the created JSON endpoint.
 
### Part 2: Create a timeline of messages
1. For each Person P provide ability to post content i.e. User can post a message.
2. If X is Friend(P) only then show that status message to user. 
 
### Part 3: Friend Suggestions 
1. If X is Friend(P) and Y is Friend(P) and X ~Friend(Y) then show friend suggestion of Y to X and vice versa.
