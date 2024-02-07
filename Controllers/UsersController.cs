using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

public class UsersController : Controller
{
    public UsersController()
    {
        
    }


    public IActionResult Login()
    {
        return View();
    }
}