using MySql.Data.MySqlClient;
using registerUser_API_2.Services.Dtos.User;
using registerUser_API_2.Services.Domains.User;

namespace registerUser_API_2.Services.Persistence.User;

public class UserPersistence : IUserPersistence
{
    private static UserPersistence? _instance;
    private MySqlConnection _dbConnection = new MySqlConnection();
    public string GetUserEndpoitName { get { return "GetUser"; } }


    public UserPersistence(string connString)
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;

        _dbConnection.ConnectionString = connString;
    }


    /* create */
    public UserDto CreateUser(UserDto user)
    {
        try
        {
            _dbConnection.Open();
            string query = "INSERT INTO (`Id`, `FirstName`, `LastName`, `Password`, `CreatedAt`, `UpdatedAt`) VALUES (@firstName, @lastName, @password, @createdAt, @updatedAt)";
            using MySqlCommand command = new MySqlCommand(query, _dbConnection);
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@createdAt", user.CreatedAt);
            command.Parameters.AddWithValue("@updatedAt", user.UpdatedAt);

            command.ExecuteNonQuery();
            // using var reader = this.dbCommand.ExecuteReader();
            // Console.WriteLine("reader {}", reader);

            return user;
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            // MessageBox.Show(ex.Message);
            Console.WriteLine($"Database connection error: {ex.Message}");
            throw;
        }
    }

    /* read all */
    public List<UserDto> GetUsers()
    {
        try
        {
            _dbConnection.Open();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            // MessageBox.Show(ex.Message);
            Console.WriteLine($"Database connection error: {ex.Message}");
            throw;
        }
        List<UserDto> users = new List<UserDto>();
        string query = "SELECT * FROM `User`;";


        MySqlCommand command = new MySqlCommand(query, _dbConnection);
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                users.Add(new UserDto(
                    reader.GetString("Id"),
                    reader.GetString("FirstName"),
                    reader.GetString("lastName"),
                    reader.GetString("Password"),
                    reader.GetDateTime("CreatedAt"),
                    reader.GetDateTime("UpdatedAt")
                ));
            }
        }
        _dbConnection.Close();
        return users;
    }

    /* read one */
    public UserDto? GetUser(string id)
    {
        try
        {
            _dbConnection.Open();
            string query = "SELECT * FROM `User`;";
            MySqlCommand command = new MySqlCommand(query, _dbConnection);

            using (MySqlDataReader reader = command.ExecuteReader())
                if (reader.Read())
                {
                    return new UserDto
                    (
                        reader.GetString("Id"),
                        reader.GetString("FirstName"),
                        reader.GetString("lastName"),
                        reader.GetString("Password"),
                        reader.GetDateTime("CreatedAt"),
                        reader.GetDateTime("UpdatedAt")
                    );
                }
            _dbConnection.Close();
            return null;
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            // MessageBox.Show(ex.Message);
            Console.WriteLine($"Database connection error: {ex.Message}");
            throw;
        }
    }

    /* update */
    public string UpdateUser(string userId, UserUpdateDto userUpdate)
    {
        try
        {
            _dbConnection.Open();
            string query = "UPDATE `User` SET `FirstName` = @firstName, `LastName` = @lastName, `Password` = @password, `UpdatedAt` = @updatedAt WHERE `Id` = @userId;";
            MySqlCommand command = new MySqlCommand(query, _dbConnection);

            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@firstName", userUpdate.FirstName);
            command.Parameters.AddWithValue("@lastName", userUpdate.LastName);
            command.Parameters.AddWithValue("@password", userUpdate.Password);
            command.Parameters.AddWithValue("@updatedAt", userUpdate.UpdatedAt);

            command.ExecuteNonQuery();

            _dbConnection.Close();
            return "User updated succesfully";
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            // MessageBox.Show(ex.Message);
            Console.WriteLine($"Database connection error: {ex.Message}");
            return "";
            // throw;
        }
    }

    /* delete */
    public string DeleteUser(string userId)
    {
        try
        {
            _dbConnection.Open();
            string query = "DELETE FROM `User` WHERE `Id` = @id";
            using MySqlCommand command = new MySqlCommand(query, _dbConnection);

            command.Parameters.AddWithValue("@id", userId);

            command.ExecuteNonQuery();

            _dbConnection.Close();
            return "User deleted succesfully";
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            // MessageBox.Show(ex.Message);
            Console.WriteLine($"Database connection error: {ex.Message}");
            throw;
        }
    }
}
