using FoodBear.Admin;
using MySqlConnector;

namespace FoodBear.AppPage
{
    public partial class LgPage : ContentPage
    {
        private MySqlConnection connection;
        private string connectionString = "server=192.168.0.155;user=root;password=;database=foodbear";

        public LgPage()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (email == "admin@gmail.com" && password == "123")
            {
                // Seller login
                await Navigation.PushAsync(new AdminPage());
                return;
            }

            try
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Users WHERE user_email = @Email AND user_password = @Password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        // User login successful
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        // Invalid email or password
                        await DisplayAlert("Login", "Invalid email or password.", "OK");
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while logging in: {ex.Message}", "OK");
            }
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

        private async void DiaryBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM test";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    List<string> myArray = new List<string>();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string name = reader.GetString("name");

                        Console.WriteLine($"Id: {id}, Name: {name}");

                        myArray.Add(name);
                    }

                    // Do something with the data in myArray

                    await DisplayAlert("Success", "Data retrieved successfully!", "OK");
                }
                await Navigation.PushAsync(new LgPage());
                connection.Close();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while retrieving data: {ex.Message}", "OK");
            }
        }
    }
}
