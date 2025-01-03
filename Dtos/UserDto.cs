using System.ComponentModel.DataAnnotations;

namespace registerUser_API_2.Dtos;

public record class UserDto(
    [Required][StringLength(50)] string Id,
    [Required][StringLength(50)] string FirstName,
    [Required][StringLength(50)] string LastName,
    [Required] string Password,
    [Required] DateTime CreatedAt,
    [Required] DateTime UpdatedAt
);
