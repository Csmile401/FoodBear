using FoodBear;

namespace FoodBear.Admin;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}