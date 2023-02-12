using LanguageExt;

namespace Server.Domain.User;

public interface IUserService
{
    Aff<UserDomainModel> Login(string email, string password);
    Aff<UserDomainModel> GetCurrentUser();
    Aff<UserDomainModel> Update(string email, string bio, string image);
}