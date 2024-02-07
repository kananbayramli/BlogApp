using BlogApp.Data.Abstract;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

public class UsersController : Controller
{

    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        return View();
    }
}