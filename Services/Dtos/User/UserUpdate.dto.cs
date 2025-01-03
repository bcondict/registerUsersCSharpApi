namespace registerUser_API_2.Services.Dtos.User;

using System.ComponentModel.DataAnnotations;

public record UserUpdateDto(
    [Required][StringLength(50)] string FirstName,
    [Required][StringLength(50)] string LastName,
    [Required] string Password,
    [Required] DateTime UpdatedAt
);
