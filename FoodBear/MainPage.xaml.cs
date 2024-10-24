using FoodBear.AppPage;
using MySqlConnector;

namespace FoodBear;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private async void OnCounterButtonClicked(object sender, EventArgs e)
    {
        {
            // Replace with your MySQL connection string
            string connectionString = "server=192.168.0.155;user=root;password=;database=foodbear";

            // Create a new MySQL connection
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Open the connection
            connection.Open();

            // Check the connection state
            if (connection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("MySQL connection is open");
            }
            else
            {
                Console.WriteLine("MySQL connection is closed");
            }

            // Close the connection
            connection.Close();
        }
        await Navigation.PushAsync(new LgPage());
    }
}

