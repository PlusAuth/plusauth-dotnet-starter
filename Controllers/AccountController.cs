using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SampleMvcApp.Controllers
{
  public class AccountController : Controller
  {
    public async Task Login(string returnUrl = "/")
    {
      await HttpContext.ChallengeAsync("PlusAuth", new AuthenticationProperties() { RedirectUri = returnUrl });
    }

    [Authorize]
    public async Task Logout()
    {
      await HttpContext.SignOutAsync("PlusAuth", new AuthenticationProperties
      {
        // Indicate that PlusAuth should redirect the user after a logout.
        RedirectUri = "/"
      });
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public IActionResult AccessDenied()
    {
      return View();
    }
  }
}