using MySqlConnector;
using System.Collections.ObjectModel;

namespace FoodBear.AppPage;

public partial class fresco : ContentPage
{
    public class FoodItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool IsSelected { get; set; }
    }

    private ObservableCollection<FoodItem> foodItems = new ObservableCollection<FoodItem>();

    public fresco()
    {
        InitializeComponent();
        // Set the binding context
        BindingContext = this;

        // Add some sample food items
        foodItems.Add(new FoodItem { Name = "Mi Goreng", Price = 6.00, Image = "mi_goreng.jpeg" });
        foodItems.Add(new FoodItem { Name = "Laksa", Price = 6.00, Image = "laksa.jpeg" });
        foodItems.Add(new FoodItem { Name = "Nasi Ayam", Price = 6.00, Image = "nasi_ayam.jpeg" });
        foodItems.Add(new FoodItem { Name = "Teh O", Price = 2.40, Image = "teh_o.jpg" });
        foodItems.Add(new FoodItem { Name = "Tec C", Price = 3.20, Image = "teh_c.jpg" });
        // Assign the food items collection to the CollectionView's ItemsSource
        foodCollectionView.ItemsSource = foodItems;
        foodCollectionView.SelectionMode = SelectionMode.Multiple;
        foodCollectionView.SelectionChanged += FoodCollectionView_SelectionChanged;
    }
    private void FoodCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Get the selected food items
        var selectedItems = e.CurrentSelection.Cast<FoodItem>().ToList();

        // Update the IsSelected property of all food items based on selection
        foreach (var foodItem in foodItems)
        {
            foodItem.IsSelected = selectedItems.Contains(foodItem);
        }

        // Update the Total property whenever the selection changes
        OnPropertyChanged(nameof(Total));
    }


    public double Total
    {
        get
        {
            double total = 0;
            foreach (var foodItem in foodItems)
            {
                if (foodItem.IsSelected)
                {
                    total += foodItem.Price;
                }
            }
            return total;
        }
    }

    private async void PlaceOrder_Clicked(object sender, EventArgs e)
    {
        List<FoodItem> selectedItems = foodItems.Where(item => item.IsSelected).ToList();

        // Save the selected items to the database
        foreach (var foodItem in selectedItems)
        {
            using (var connection = new MySqlConnection("server=192.168.0.155;user=root;password=;database=foodbear"))
            {
                await connection.OpenAsync();

                var query = $"INSERT INTO fooditem (Name, Price) VALUES (@Name, @Price)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", foodItem.Name);
                    command.Parameters.AddWithValue("@Price", foodItem.Price);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Perform further actions with the selected food items
        await DisplayAlert("Success", "Your Order has been placed!", "OK");
        await Navigation.PushAsync(new CartPage());
    }
}