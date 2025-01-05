using registerUser_API_2.Services.Domains.User;
using registerUser_API_2.Services.Dtos.User;

namespace registerUser_API_2.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app, string route, IUserPersistence UserPersistence)
    {
        RouteGroupBuilder group = app.MapGroup(route).WithParameterValidation();

        /* GET /users - list the users */
        group.MapGet("/", () => UserPersistence.GetUsers());


        /* GET /users/{userId} - get only one user with spected id*/
        group.MapGet("/{id}", (string id) =>
        {
            UserDto? user = UserPersistence.GetUser(id);
            return user is null ? Results.NotFound() : Results.Ok(user);
        }).WithName(UserPersistence.GetUserEndpoitName!);

        /* POST /users - create a new user with the info passed by the client */
        group.MapPost("/", (UserDto newUser) =>
        {
            UserPersistence.CreateUser(newUser);
            return Results.CreatedAtRoute(UserPersistence.GetUserEndpoitName, new { id = newUser.Id }, newUser);
        });

        /* PUT /users/{userId} - update a user record */
        group.MapPut("/{id}", (string id, UserUpdateDto userUpdate) =>
        {
            string isUserUpdated = UserPersistence.UpdateUser(id, userUpdate);
            return isUserUpdated is "" ? Results.NotFound() : Results.Ok(isUserUpdated);
        });

        /* DELETE /users/{userId} - delete an speceific record by its id */
        group.MapDelete("/{id}", (string id) =>
        {
            UserPersistence.DeleteUser(id);
            return Results.NoContent();
        });

        return group;
    }
}
