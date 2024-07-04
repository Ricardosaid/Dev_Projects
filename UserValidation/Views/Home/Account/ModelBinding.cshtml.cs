using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserValidation.Views.Home.Account;

public class ModelBinding : PageModel
{
    [BindProperty]
    public Credential Credential { get; set; }
    
    public void OnGet()
    {
        
    }

    public void OnPost()
    {
    }
}
public class Credential
{
    [Required]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
        
}