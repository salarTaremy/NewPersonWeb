using Microsoft.AspNetCore.Identity;

namespace NewPersonWeb
{
    public class ApplicationUser : IdentityUser {

        public string FullName { get; set; }
        public string WebPassword { get; set; }


    }
}
