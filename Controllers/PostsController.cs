using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

public class PostsController : Controller
{
    private IPostRepository _postrepository;
    private ITagRepository _tagRepository;

    public PostsController(IPostRepository postrepository, ITagRepository tagRepository)
    {
        _postrepository = postrepository;
        _tagRepository = tagRepository;
    }

    public IActionResult Index()
    {
        return View(
            new PostsViewModel{
                Posts = _postrepository.Posts.ToList(),
                Tags = _tagRepository.Tags.ToList()
            }
        );
    }
}