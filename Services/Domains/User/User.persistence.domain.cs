using registerUser_API_2.Services.Dtos.User;

namespace registerUser_API_2.Services.Domains.User;

public interface IUserPersistence
{
    string? GetUserEndpoitName { get; }

    UserDto CreateUser(UserDto user);
    List<UserDto> GetUsers();
    UserDto? GetUser(string userId);
    string UpdateUser(string userId, UserUpdateDto userUpdate);
    string DeleteUser(string userId);
}
