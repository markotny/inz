using Microsoft.AspNetCore.Identity;

namespace AuthServer.Models
{
    public class RegisterResponseViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public RegisterResponseViewModel(IdentityUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
        }
    }
}
