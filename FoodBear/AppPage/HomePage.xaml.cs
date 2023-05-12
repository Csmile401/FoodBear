using System.Collections.ObjectModel;

namespace FoodBear.AppPage;

public partial class HomePage : ContentPage
{
    public ObservableCollection<string> Images { get; set; }
    public class ImageItem
    {
        public string Source { get; set; }
    }
    public HomePage()
	{
		InitializeComponent();

        var images = new List<ImageItem>
        {
            new ImageItem { Source = "ad1.png" },
            new ImageItem { Source = "ad2.png" },
            new ImageItem { Source = "ad3.png" }
        };

        carouselView.ItemsSource = images;

    }
    //<!--table of food choose-->
    private async void MartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MartPage());
    }
    private async void OrderClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OrderPage());
    }
    private async void FoodClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FoodPage());
    }

    //<!-- Bottom tab bar -->
    private async void OnTab1Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new LgPage());
    }
    private async void OnTab2Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CartPage());
    }
    private async void OnTab3Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }

    private void BoxView_BindingContextChanged(object sender, EventArgs e)
    {

    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {

    }
}