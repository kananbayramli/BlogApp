using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

public class PostsController : Controller
{
    private IPostRepository _postrepository;

    public PostsController(IPostRepository postrepository)
    {
        _postrepository = postrepository;
    }

    public IActionResult Index()
    {
        return View(
            new PostsViewModel
            {
                Posts = _postrepository.Posts.ToList()
            }
        );
    }
}