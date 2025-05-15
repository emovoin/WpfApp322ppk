using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp322
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow(List<Product> products, Dictionary<int, int> purchaseStatistics)
        {
            InitializeComponent();

            var stats = products.Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                SalesCount = purchaseStatistics.ContainsKey(p.Id) ? purchaseStatistics[p.Id] : 0,
                TotalRevenue = (purchaseStatistics.ContainsKey(p.Id) ? purchaseStatistics[p.Id] : 0) * p.Price
            }).ToList();

            ProductsStatsListView.ItemsSource = stats;
        }
    }
}
