using System.Security.Claims;
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
    public JsonResult AddComment(int PostId, string Text)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var username = User.FindFirstValue(ClaimTypes.Name);
        var avatar = User.FindFirstValue(ClaimTypes.UserData);


        var entity = new Comment {
            Text = Text,
            PostId = PostId,
            PublishedOn = DateTime.Now,
            UserId = int.Parse(userId ?? "")
        };
        _commentRepository.CreateComment(entity);

        return Json(new {
            username,
            Text,
            entity.PublishedOn,
            avatar
        });
    }



    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(PostCreateViewModel model)
    {
        if(ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _postrepository.CreatePost(
                new Post{
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content,
                    Url = model.Url,
                    PublishedOn = DateTime.Now,
                    UserId = int.Parse(userId ?? ""),
                    Image = "photodefpost.jpg",
                    IsActive = false
                }
            );
            return RedirectToAction("Index");
        }
        return View(model);
    }





}