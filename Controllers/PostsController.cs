using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers;

public class PostsController : Controller
{
    private IPostRepository _postrepository;
    private ICommentRepository _commentRepository;

    public PostsController(IPostRepository postrepository, ICommentRepository commentRepository)
    {
        _postrepository = postrepository;
        _commentRepository = commentRepository;
    }


    public async Task<IActionResult> Index(string tag)
    {

        var claims = User.Claims;

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



    [HttpPost]
    public JsonResult AddComment(int PostId, string UserName, string Text)
    {
        var entity = new Comment {
            Text = Text,
            PostId = PostId,
            PublishedOn = DateTime.Now,
            User = new User {UserName = UserName, Image = "p1.jpg"}
        };
        _commentRepository.CreateComment(entity);

        return Json(new {
            UserName,
            Text,
            entity.PublishedOn,
            entity.User.Image
        });
    }
}