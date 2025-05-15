using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp322.ViewModel
{
    internal class CartWindowViewModel
    {
        //private List<CartItem> cart;
        //private MainWindow mainWindow;

        //this.cart = cart;
        //    this.mainWindow = mainWindow;
        //    CartItemsListView.ItemsSource = cart;
        //    UpdateTotalPrice();

        //private void UpdateTotalPrice()
        //{
        //    TotalPriceText.Text = cart.Sum(item => item.TotalPrice).ToString("C");
        //}

        //private void RemoveItem_Click(object sender, RoutedEventArgs e)
        //{
        //    Button button = (Button)sender;
        //    int productId = (int)button.Tag;

        //    var itemToRemove = cart.FirstOrDefault(item => item.ProductId == productId);
        //    if (itemToRemove != null)
        //    {
        //        cart.Remove(itemToRemove);
        //        CartItemsListView.Items.Refresh();
        //        UpdateTotalPrice();
        //        mainWindow.UpdateCartCount();
        //    }
        //}

        //private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (cart.Count == 0)
        //    {
        //        MessageBox.Show("Корзина пуста!");
        //        return;
        //    }

        //    var purchasedItems = cart.ToDictionary(item => item.ProductId, item => item.Quantity);
        //    mainWindow.CompletePurchase(purchasedItems);

        //    MessageBox.Show("Заказ оформлен! Спасибо за покупку!");
        //    this.Close();
        //}
    }
}
