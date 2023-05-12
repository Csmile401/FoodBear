using FoodBear.Admin;

namespace FoodBear.AppPage;

public partial class LgPage : ContentPage
{
	public LgPage()
	{
		InitializeComponent();
	}

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        if (EmailEntry.Text == "admin@gmail.com" && PasswordEntry.Text == "123")
        {
            // Admin login
            await Navigation.PushAsync(new AdminPage());
        }
        else if (EmailEntry.Text == "foodbear@gmail.com" && PasswordEntry.Text == "123")
        {
            // User login
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            await DisplayAlert("Login", "Invalid Email or Password", "OK");
        }
    }

    private async void OnSignUpButtonClicked(object sender, EventArgs e)
    {
        // Navigate to the SignUp page
        await Navigation.PushAsync(new SignUp());
    }

}