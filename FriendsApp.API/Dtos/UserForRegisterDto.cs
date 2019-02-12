using System.ComponentModel.DataAnnotations;

namespace FriendsApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required] // can't be nullor empty, DataAnnotation valication
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password length must between 4 and 8.")]
        public string Password { get; set; }
    }
}