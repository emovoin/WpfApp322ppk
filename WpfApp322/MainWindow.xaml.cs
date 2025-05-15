using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp322
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Product> products = new List<Product>();
        private List<CartItem> cart = new List<CartItem>();
        private Dictionary<int, int> purchaseStatistics = new Dictionary<int, int>();

        public MainWindow()
        {
            InitializeComponent();
            //LoadProducts();
            LoadStatistics();
            UpdateCartCount();
        }

        //private void LoadProducts()
        //{
        //    // Загрузка тестовых данных
        //    products.Add(new Product { Id = 1, Name = "Футболка", Description = "Хлопковая футболка", Price = 999, ImagePath = "images/tshirt.jpg" });
        //    products.Add(new Product { Id = 2, Name = "Джинсы", Description = "Классические джинсы", Price = 2499, ImagePath = "images/jeans.jpg" });
        //    products.Add(new Product { Id = 3, Name = "Куртка", Description = "Демисезонная куртка", Price = 4999, ImagePath = "images/jacket.jpg" });
        //    products.Add(new Product { Id = 4, Name = "Платье", Description = "Вечернее платье", Price = 3599, ImagePath = "images/dress.jpg" });

        //    ProductsListView.ItemsSource = products;
        //}

        private void LoadStatistics()
        {
            // Имитация загрузки статистики (в реальном приложении загружали бы из БД)
            foreach (var product in products)
            {
                purchaseStatistics[product.Id] = 0;
            }
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int productId = (int)button.Tag;

            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                var existingItem = cart.FirstOrDefault(item => item.ProductId == productId);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { ProductId = productId, ProductName = product.Name, Price = product.Price, Quantity = 1 });
                }

                UpdateCartCount();
                MessageBox.Show($"{product.Name} добавлен в корзину!");
            }
        }

        public void UpdateCartCount()
        {
            CartItemsCount.Text = cart.Sum(item => item.Quantity).ToString();
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow(cart, this);
            cartWindow.ShowDialog();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка пароля (в реальном приложении более сложная аутентификация)
            var passwordWindow = new PasswordWindow();
            if (passwordWindow.ShowDialog() == true)
            {
                AdminWindow adminWindow = new AdminWindow(products, purchaseStatistics);
                adminWindow.ShowDialog();
            }
        }

        public void CompletePurchase(Dictionary<int, int> purchasedItems)
        {
            foreach (var item in purchasedItems)
            {
                if (purchaseStatistics.ContainsKey(item.Key))
                {
                    purchaseStatistics[item.Key] += item.Value;
                }
            }

            cart.Clear();
            UpdateCartCount();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}