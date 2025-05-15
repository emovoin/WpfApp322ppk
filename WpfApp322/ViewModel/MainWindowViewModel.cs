using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using WpfApp322.Model;
using WpfApp322.VMTools;

namespace WpfApp322.ViewModel
{
    internal class MainWindowViewModel : BaseVM
    {        
        private List<Products> products;
        private string name;
        private int price;
        private int id;

        public List<Products> Products 
        { 
            get => products;
            set
            {
                products = value;
                Signal();
            }
        }
       

        public MainWindowViewModel()
        {
                       SelectAll();
        }

        private void SelectAll()
        {
            Products = new List<Products>(ProductDB.GetDb().SelectAll());
        }




        //private void AddToCart_Click(object sender, RoutedEventArgs e)
        //{
        //    Button button = (Button)sender;
        //    int productId = (int)button.Tag;

        //    var product = products.FirstOrDefault(p => p.Id == productId);
        //    if (product != null)
        //    {
        //        var existingItem = cart.FirstOrDefault(item => item.ProductId == productId);
        //        if (existingItem != null)
        //        {
        //            existingItem.Quantity++;
        //        }
        //        else
        //        {
        //            cart.Add(new CartItem { ProductId = productId, ProductName = product.Name, Price = product.Price, Quantity = 1 });
        //        }

        //        UpdateCartCount();
        //        MessageBox.Show($"{product.Name} добавлен в корзину!");
        //    }
        //}

        //public void UpdateCartCount()
        //{
        //    CartItemsCount.Text = cart.Sum(item => item.Quantity).ToString();
        //}





        //public void CompletePurchase(Dictionary<int, int> purchasedItems)
        //{
        //    foreach (var item in purchasedItems)
        //    {
        //        if (purchaseStatistics.ContainsKey(item.Key))
        //        {
        //            purchaseStatistics[item.Key] += item.Value;
        //        }
        //    }

        //    cart.Clear();
        //    UpdateCartCount();
        //}
    }



    //public class CartItem
    //{
    //    public int ProductId { get; set; }
    //    public string ProductName { get; set; }
    //    public decimal Price { get; set; }
    //    public int Quantity { get; set; }
    //    public decimal TotalPrice => Price * Quantity;
    //}
}

