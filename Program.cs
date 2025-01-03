using registerUser_API_2.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapUsersEndpoints("/users");


app.Run();
