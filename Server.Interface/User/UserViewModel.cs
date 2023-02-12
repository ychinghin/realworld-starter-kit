using Server.Domain.User;

namespace Server.Interface.User;

public record UserViewModel
(
    string Bio,
    string Username,
    string Image,
    string Email,
    string Token
)
{
    public static explicit operator UserViewModel(UserDomainModel domain) =>
        new(
            domain.Bio,
            domain.Username,
            domain.Image,
            domain.Email,
            ""
        );
};

public record UserProfileViewModel
(
    string Bio,
    string Username,
    string Image,
    bool Following
);

public record UserLoginRequest
(
    string Email,
    string Password
);

public record UserRegisterRequest
(
    string Username,
    string Email,
    string Password
);

public record UserUpdateRequest
(
    string Email,
    string Bio,
    string Image
);

