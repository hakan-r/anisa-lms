using anisa_lms.Models;

namespace anisa_lms.Interfaces
{
    public interface ITokenService
    {
        public string GenerateJwtToken(AppUser user, string role);
    }
}
