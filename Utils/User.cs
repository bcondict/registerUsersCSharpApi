namespace registerUser_API_2.Utils.User;

using registerUser_API_2.Dtos;

public static class UserDB
{
    private static List<UserDto> _users = new List<UserDto>()
    {
        new UserDto(
            "97146459-6503-40c4-b8d0-1cca64eb1832",
            "Jesus",
            "Junco",
            "password",
            DateTime.Now,
            DateTime.Now
        ),
        new UserDto(
            "14c18096-7efa-45b7-ae24-f9be96a4f293",
            "Luna",
            "Gomez",
            "password",
            DateTime.Now,
            DateTime.Now
        ),
        new UserDto(
            "d03cf1df-a957-4556-a822-514a1f1c5614",
            "Juan",
            "Avila",
            "password",
            DateTime.Now,
            DateTime.Now
        )
    };

    public static string GetUserEndpoitName { get { return "GetUser"; } }

    /* create */
    public static UserDto CreateUser(UserDto user)
    {
        _users.Add(user);
        return user;
    }

    /* read all */
    public static List<UserDto> GetUsers()
    {
        return _users;
    }

    /* read one */
    public static UserDto? GetUser(string id)
    {
        return _users.Find(user => user.Id == id);
    }

    /* update */
    public static UserDto UpdateUser(string userId, UserUpdateDto userUpdate)
    {
        int userIndex = _users.FindIndex(user => user.Id == userId);

        UserDto oldUser = _users[userIndex];
        oldUser = new UserDto(
            userId,
            userUpdate.FirstName,
            userUpdate.LastName,
            userUpdate.Password,
            oldUser.CreatedAt,
            userUpdate.UpdatedAt
        );

        return oldUser;
    }

    /* delete */
    public static void DeleteUser(string userId)
    {
        _users.RemoveAll(user => user.Id == userId);
    }
}
