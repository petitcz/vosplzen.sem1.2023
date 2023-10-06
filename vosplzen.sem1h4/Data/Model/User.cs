using Microsoft.AspNetCore.Identity;

namespace vosplzen.sem1h4.Data.Model
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
