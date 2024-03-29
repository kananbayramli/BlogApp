using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models;

public class RegisterViewModel
{
    [Required]
    [Display(Name ="Username")]
    public string? UserName { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    [Display(Name ="Confirm Password")]
    public string? ConfirmPassword { get; set; }


}