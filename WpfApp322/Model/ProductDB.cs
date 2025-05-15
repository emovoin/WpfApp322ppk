using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows;

namespace WpfApp322.Model
{
    internal class ProductDB
    {
        DbConnection connection;

        private ProductDB(DbConnection db)
        {
            connection = db;
        }
        internal List<Products> SelectAll()
        {
            List<Products> products = new List<Products>();
            if (connection == null)
                return products;

            if (connection.OpenConnection())
            {
                var command = connection.CreateCommand("select `Id`, `Name`, `Price`, `Image`, `Description` from `Products` ");
                try
                {
                    MySqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);

                        string name = string.Empty;
                        if (!dr.IsDBNull(1))
                            name = dr.GetString("Name");

                        int price = 0;
                        if (!dr.IsDBNull(2))
                            price = dr.GetInt32("Price");

                        byte[] photo = null;
                        if (!dr.IsDBNull(3))
                        {
                            long size = dr.GetBytes(5, 0, null, 0, 0);
                            photo = new byte[size];
                            dr.GetBytes(5, 0, photo, 0, (int)size);
                        }

                        string description = string.Empty;
                        if (!dr.IsDBNull(4))
                            description = dr.GetString("Description");

                        products.Add(new Products
                        {
                            Id = id,
                            Name = name,
                            Price = price,
                            Image = photo,
                            Description = description
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

        static ProductDB db;
        public static ProductDB GetDb()
        {
            if (db == null)
                db = new ProductDB(DbConnection.GetDbConnection());
            return db;
        }
    }
}
