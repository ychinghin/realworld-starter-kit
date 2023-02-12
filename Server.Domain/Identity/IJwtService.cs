using Server.Domain.User;

namespace Server.Domain.Identity;

public interface IJwtService
{
    string GenerateToken(UserDomainModel user);
}