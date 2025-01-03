namespace registerUser_API_2.Dtos;

public record UserUpdateDto(
    string FirstName,
    string LastName,
    string Password,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
