using MySqlConnector;

namespace FoodBear.AppPage
{
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            string fullName = NameEntry.Text;
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;
            string phoneNumber = PhoneEntry.Text;
            DateTime birthdate = BirthdatePicker.Date;
            bool agreedToTerms = AgreeCheckBox.IsChecked;

            // Validate user input
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(phoneNumber) ||
                !agreedToTerms)
            {
                await DisplayAlert("Error", "Please fill in all the required fields.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            // TODO: Perform additional validation or business logic

            // Save user data to the database
            string connectionString = "server=192.168.0.155;user=root;password=;database=foodbear";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Users (user_name, user_email, user_password, phone_number, Birthdate) " +
                               "VALUES (@FullName, @Email, @Password, @PhoneNumber, @Birthdate)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Birthdate", birthdate);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        await DisplayAlert("Success", "Registration successful.", "OK");
                        await Navigation.PushAsync(new LgPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Registration failed.", "OK");
                    }
                }
            }
        }
    }
}
