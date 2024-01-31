using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers;

public class PostsController : Controller
{
    private IPostRepository _postrepository;

    public PostsController(IPostRepository postrepository)
    {
        _postrepository = postrepository;
    }

    public async Task<IActionResult> Index(string tag)
    {

        var posts = _postrepository.Posts;

        if(!string.IsNullOrEmpty(tag))
        {
            posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
        }

        return View(
            new PostsViewModel{Posts = await posts.ToListAsync()});
    }




    public async Task<IActionResult> Details(string url)
    {
        return View(await _postrepository
                            .Posts
                            .Include(x => x.Tags)
                            .Include(X => X.Comments)
                            .ThenInclude(x => x.User)
                            .FirstOrDefaultAsync(p => p.Url == url));
    }
}