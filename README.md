# Plusauth ASP.NET Core 3 Starter Project



This is a very simple ASP.NET Core project demonstrating basic authentication flows such as register, login and logout. To keep things simple we used ASP.NET Core 3 as the server framework and Microsoft.AspNetCore.Authentication.OpenIdConnect for authentication.


## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [License](#license)

## Prerequisites
Before running the project, you must first follow these steps:

1) Create a Plusauth account and a tenant at https://dashboard.plusauth.com
2) Navigate to `Clients` tab and create a client of type `Regular Web Application`.
3) Go to details page of the client that you've just created and set the following fields as:
* Redirect Uris: https://localhost:5001/login/callback
* Post Logout Redirect Uris: https://localhost:5001/


 Finally write down your Client Id and Client Secret for server configuration 
## Getting Started

First we need to configure the server. Open file named 'appsettings.json'.

Then configure the file using your Client Id, Client Secret and your Plusauth tenant name.


Finally start the server:

        dotnet watch run
    

The example is hosted at https://localhost:5001/

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.
