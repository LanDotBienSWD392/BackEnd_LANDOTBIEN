using System.ComponentModel.DataAnnotations;

namespace LanVar.DTO.DTO.request;

public class LoginDTORequest
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}