namespace registerUser_API_2.Endpoints;

using registerUser_API_2.Dtos.User;
using registerUser_API_2.Utils.User;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app, string route)
    {
        RouteGroupBuilder group = app.MapGroup(route);

        /* GET /users - list the users */
        group.MapGet("/", () => UserDB.GetUsers());


        /* GET /users/{userId} - get only one user with spected id*/
        group.MapGet("/{id}", (string id) =>
        {
            UserDto? user = UserDB.GetUser(id);
            return user is null ? Results.NotFound() : Results.Ok(user);
        }).WithName(UserDB.GetUserEndpoitName);

        /* POST /users - create a new user with the info passed by the client */
        group.MapPost("/", (UserDto newUser) =>
        {
            UserDB.CreateUser(newUser);
            return Results.CreatedAtRoute(UserDB.GetUserEndpoitName, new { id = newUser.Id }, newUser);
        });

        /* PUT /users/{userId} - update a user record */
        group.MapPut("/{id}", (string id, UserUpdateDto userUpdate) =>
        {
            UserDto? user = UserDB.UpdateUser(id, userUpdate);
            return user is null ? Results.NotFound() : Results.Ok(user);
        });

        /* DELETE /users/{userId} - delete an speceific record by its id */
        group.MapDelete("/{id}", (string id) =>
        {
            UserDB.DeleteUser(id);
            return Results.NoContent();
        });

        return group;
    }
}
