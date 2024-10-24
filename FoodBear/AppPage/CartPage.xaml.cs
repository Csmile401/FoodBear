namespace FoodBear.AppPage
{
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();

            // Set the data context to the view model or provide the data for the ListView
            receiptListView.ItemsSource = GetReceiptItems(); // Replace this with your actual data source
        }

        // Method to provide sample data for the ListView
        private List<ReceiptItem> GetReceiptItems()
        {
            return new List<ReceiptItem>
            {
                new ReceiptItem { UserName = "John Doe", UserPhone = "017-654-3210", FoodName = "Mi Goreng", FoodPrice = 6.00 },
                new ReceiptItem { UserName = "John Doe", UserPhone = "017-654-3210", FoodName = "Tea C", FoodPrice = 3.20 },
                // Add more items as needed
            };
        }
    }

    // Model class for the receipt item
    public class ReceiptItem
    {
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
    }
}
