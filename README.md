# RapidCircle-CodeChallange
RapidCircle-CodeChallange

## Demo
### Video links for demo
#### Existing user flow
https://youtu.be/o9dwYPq7-Ao

#### New user flow
https://youtu.be/JbCVerVOzOM


## Specifications

* ASP.NET MVC Web App with AngularJS
* Backend usig ASP.NET WebApi 2
* Graph using GoJS
* MS SQL Server as Primary Database
* version-control: Git
* Authentication and user management using MS Azure Active Directory B2C


## How To Use
* Clone repository to your machine
* Extract and open in visual studio (2015 or later)
* Change Web configs with your Azure AD B2C application settingss and app endpoint
* Run API first, then WebApp.
* Done!
* Now you can see timeline - friends posts. Add friends. Get suggestions. And visualize network with graph.
* local Urls:
* Api: https://localhost:44388/
* WebApp: https://localhost:44328/
* Note: If you face SSL issue, just bypass it in code using `ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;` or install self signed certificate


## Demo Apps
* Api:https://friendsapi.azurewebsites.net
* WebApp: https://friendsweb.azurewebsites.net
