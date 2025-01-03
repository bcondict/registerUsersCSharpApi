using Microsoft.EntityFrameworkCore;

using registerUser_API_2.Services.Entities;

namespace registerUser_API_2.Data.Users;

public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
{
    public DbSet<User> users => Set<User>();
}
