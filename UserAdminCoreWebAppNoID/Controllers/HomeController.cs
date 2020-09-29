using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAdminCoreWebAppNoID.Models;
using UserAdminCoreWebAppNoID.Services;

namespace UserAdminCoreWebAppNoID.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly UserService _userService;

    public HomeController(ILogger<HomeController> logger, UserService userService)
    {
      _logger = logger;
      _userService = userService;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult SignUp()
    {
      ViewBag.Message = "User Sign Up";

      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SignUp(UserModel model)
    {
      if (ModelState.IsValid)
      {
        if (_userService.UserAlreadyExists(model.EmailAddress))
        {
          ModelState.AddModelError(string.Empty, $"Email address {model.EmailAddress} is already registered.");
        }
        else
        {
          _userService.CreateUserAccount(model);

          ViewData.Add("EmailAddress", $"{model.EmailAddress}");

          return View("SignedUp");
        }
      }

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
