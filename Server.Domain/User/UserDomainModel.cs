namespace Server.Domain.User;

public record UserDomainModel
(
    string Username,
    string Email,
    string Bio,
    string Image
);