using Microsoft.AspNetCore.Identity;

namespace Utils.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IList<RefreshToken>? RefreshTokens { get; set; }
        public ApplicationUser()
        {
            RefreshTokens = new List<RefreshToken>();
        }
    }
}
