namespace registerUser_API_2.Services.Dtos.User;

using System.ComponentModel.DataAnnotations;

public record class UserDto(
    [Required][StringLength(50)] string Id,
    [Required][StringLength(50)] string FirstName,
    [Required][StringLength(50)] string LastName,
    [Required] string Password,
    [Required] DateTime CreatedAt,
    [Required] DateTime UpdatedAt
);
