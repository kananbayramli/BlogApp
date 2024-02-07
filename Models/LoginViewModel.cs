using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models;

public class LoginViewModel 
{
    [Required]
    [EmailAddress]
    [Display(Name ="Email Adress")]
    public string? Email { get; set; }

    [Required]
    [StringLength(10, ErrorMessage = "Maks 10 simvol olmalidir..."), MinLength(4, ErrorMessage ="Minimum 4 simbol olmmalidir..")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}