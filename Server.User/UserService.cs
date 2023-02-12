using LanguageExt;
using Server.Domain.Identity;
using Server.Domain.User;
using static LanguageExt.Prelude;

namespace Server.User;

public class UserService : IUserService
{
    private readonly IJwtService _jwtService;
    public UserService(IJwtService jwtService) {
        _jwtService = jwtService;
    }

    public Aff<UserDomainModel> Login(string email, string password) =>
        from user in SuccessAff(new UserDomainModel("name", "email", "bio", "image"))
        let token = _jwtService.GenerateToken(user)
        select user;

    public Aff<UserDomainModel> GetCurrentUser() =>
        from user in SuccessAff(new UserDomainModel("name", "email", "bio", "image"))
        select user;

    public Aff<UserDomainModel> Update(string email, string bio, string image) =>
        from user in SuccessAff(new UserDomainModel("name", "email", "bio", "image"))
        select user;
}
