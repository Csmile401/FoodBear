using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace FoodBear.AppPage;

public partial class MartPage : ContentPage
{
    public MartPage()
	{
		InitializeComponent();
    }

    private async void Button1_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new MartPage());
    }
    private async void Button2_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new OrderPage());
    }
    private async void Button3_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new FoodPage());
    }
    private async void Button4_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new FoodPage());
    }
}
