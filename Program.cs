using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add runtime compilation for hot reload
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(options =>
{
  // If an authentication cookie is present, use it to get authentication information
  options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
  options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie() // cookie authentication middleware first
.AddOpenIdConnect("PlusAuth", options =>
{
  options.ClientId = builder.Configuration["Plusauth:ClientId"];
  options.ClientSecret = builder.Configuration["Plusauth:ClientSecret"];
  options.Authority = builder.Configuration["Plusauth:AuthUrl"];
  options.ResponseType = "code";
  options.Scope.Clear();
  options.Scope.Add("openid");
  options.Scope.Add("email");
  options.Scope.Add("profile");
  // Get user info after authentication
  options.GetClaimsFromUserInfoEndpoint = true;
  //This is important to get user information
  ClaimActionCollectionMapExtensions.MapAll(options.ClaimActions); // Map All user information into User Claims
  // Set Authentication Issuer
  options.ClaimsIssuer = "PlusAuth";
  options.CallbackPath = new PathString("/callback");

  options.Events = new OpenIdConnectEvents
  {
    // Configure post logout redirect
    // This section provides logout action for PlusAuth
    OnRedirectToIdentityProviderForSignOut = (context) =>
    {
      // Set PlusAuth logout endpoint
      var logoutUri = $"{builder.Configuration["Plusauth:AuthUrl"]}/oidc/logout?client_id={builder.Configuration["Plusauth:ClientId"]}";

      var postLogoutUri = context.Properties.RedirectUri;
      if (!string.IsNullOrEmpty(postLogoutUri))
      {
        if (postLogoutUri.StartsWith("/"))
        {
          postLogoutUri = context.Request.Scheme + "://" + context.Request.Host + context.Request.PathBase + postLogoutUri;
        }
        // Return index page after logout
        logoutUri += $"&post_logout_redirect_uri={ Uri.EscapeDataString(postLogoutUri)}";
      }

      context.Response.Redirect(logoutUri);
      context.HandleResponse();

      return Task.CompletedTask;
    }
  };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
// Use authorization to protect endpoints
app.UseAuthorization();
app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
