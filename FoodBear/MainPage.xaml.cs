using FoodBear.AppPage;

namespace FoodBear;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private async void OnCounterButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LgPage());
    }
}

