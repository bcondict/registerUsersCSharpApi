using registerUser_API_2.Endpoints;
using registerUser_API_2.Services.Persistence.User;
using registerUser_API_2.Services.Domains.User;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

DotNetEnv.Env.Load();

string dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
string dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "root";
string dbUserPassword = Environment.GetEnvironmentVariable("DB_USER_PWD") ?? "";
string dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "registerUser";
string connString = $"server={dbHost};uid={dbUser};pwd={dbUserPassword};database={dbName}";

IUserPersistence persistence = UserPersistence.GetInstance(connString);

app.MapUsersEndpoints("/users", persistence);



app.Run();
