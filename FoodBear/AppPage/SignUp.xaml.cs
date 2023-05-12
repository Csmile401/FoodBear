namespace FoodBear.AppPage;

public partial class SignUp : ContentPage
{
	public SignUp()
	{
		InitializeComponent();
	}
    private async void OnSignUpButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(EmailEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please fill out all required fields.", "OK");
            return;
        }

        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        if (!AgreeCheckBox.IsChecked)
        {
            await DisplayAlert("Error", "Please agree to the terms and conditions.", "OK");
            return;
        }

        // TODO: Add code to create user account and navigate to next page

        await DisplayAlert("Success", "Your account has been created.", "OK");
        {
            Preferences.Set("UserEmail", EmailEntry.Text);
            Preferences.Set("UserPassword", PasswordEntry.Text);
        }
            await Navigation.PushAsync(new LgPage());
        
    }
}