<div align="center">
  <a href="https://plusauth.com/">
    <img src="https://docs.plusauth.com/favicon.png" alt="Logo" width="144">
  </a>
</div>

<h1 align="center">PlusAuth ASP.NET Core 6.0 Starter Project</h1>

 <p align="center">
    Simple ASP.NET Core 6.0 project demonstrates basic authentication flows with PlusAuth
    <br />
    <br />
    <a href="https://docs.plusauth.com/quickStart/web/dotnet-core" target="_blank"><strong>Explore the PlusAuth ASP.NET Core 6.0 docs »</strong></a>
</p>

<details>
  <summary>Table of Contents</summary>
    <li><a href="#about-the-project">About The Project</a></li>
    <li><a href="#prerequisites">Prerequisites</a></li>
    <li><a href="#getting-started">Getting Started</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#what-is-plusauth">What is PlusAuth</a></li>
 </ol>
</details>

---

## About The Project

This is a very simple ASP.NET Core project demonstrating basic authentication flows such as register, login and logout. To keep things simple we used ASP.NET Core 6.0 as the server framework and
`Microsoft.AspNetCore.Authentication.OpenIdConnect` for authentication.

## Prerequisites

Before running the project, you must first follow these steps:

1. Create a Plusauth account and a tenant at https://dashboard.plusauth.com
2. Navigate to `Clients` tab and create a client of type `Regular Web Application`.
3. Go to details page of the client that you've just created and set the following fields as:

- Redirect Uris: https://localhost:7200/callback
- Post Logout Redirect Uris: https://localhost:7200/

Finally write down your Client Id and Client Secret for server configuration

## Getting Started

First we need to configure the server. Open file named `appsettings.json`.

Then configure the file using your Client Id, Client Secret and your Plusauth tenant name.

Finally start the server:

    dotnet watch run

The example is hosted at https://localhost:7200/

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.

## What is PlusAuth

PlusAuth helps to individuals, team and organizations for implementing authorization and authentication system in a secure, flexible and easy way.

<a href="https://plusauth.com/" target="_blank"><strong>Explore the PlusAuth Website »</strong></a>

<a href="https://docs.plusauth.com/" target="_blank"><strong>Explore the PlusAuth Docs »</strong></a>

<a href="https://forum.plusauth.com/" target="_blank"><strong>Explore the PlusAuth Forum »</strong></a>
