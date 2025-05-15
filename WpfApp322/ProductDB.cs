using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows;

namespace WpfApp322
{
    internal class ProductDB
    {
        DbConnection connection;

        private ProductDB(DbConnection db)
        {
            this.connection = db;
        }
        internal List<Products> SelectAll()
        {
            List<Products> products = new List<Products>();
            if (connection == null)
                return products;

            if (connection.OpenConnection())
            {
                var command = connection.CreateCommand("select `id`, `name`, `price` from `Products` ");
                try
                {
                    MySqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string name = string.Empty;
                        if (!dr.IsDBNull(1))
                            name = dr.GetString("name");
                        int price = dr.GetInt32("price");
                        products.Add(new Products
                        {
                            ID = id,
                            Name = name,
                            Price = price
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.CloseConnection();

            return products;
        }
    }
}
