using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models;

public class PostCreateViewModel 
{
    [Required]
    [Display(Name ="Bashliq")]
    public string? Title { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public string? Content { get; set; }

    [Required]
    public string? Url { get; set; }


}