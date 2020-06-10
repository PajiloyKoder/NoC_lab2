using MySql.Data.MySqlClient;
using NoC_lab1.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NoC_lab1.DB
{
    class ProductRepository : IRepository<Product>
    {
        private MySqlConnection conn;



        public ProductRepository()
        {
            conn = DBcon.GetDBConnection();
        }

        public void Create(Product item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            string sql = $"delete from anime_shop.product where idProduct = {id};";

            cmd.Connection = conn;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

       

        public IEnumerable<Product> GetSome(IEnumerable<int> ids)
        {
            conn.Open();
            string sql = $"Select * from Product limit 100";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            List<Product> Products = new List<Product>();

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Product Product = new Product();
                        Product.IdProduct = int.Parse(reader.GetString(0));
                        Product.Name = reader.GetString(1);
                        Product.Price = int.Parse(reader.GetString(2));
                        Product.Quantity = int.Parse(reader.GetString(3));
                        Product.info = reader.GetString(4);
                        Product.idManufacturer = int.Parse(reader.GetString(5));
                        Product.idProduct_type = int.Parse(reader.GetString(6));
                        Products.Add(Product);
                    }
                }
            }
            conn.Close();
            return Products;
        }

        public void Update(Product product)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();

            long id = cmd.LastInsertedId;
            string sql = $"UPDATE anime_shop.product " +
            "set Name=" + $"'{product.Name}'," +
            "Price = " + $"{product.Price}," +
            "Quantity = " + $"'{product.Quantity}'," +
            "info = " + $"'{product.info}'," +
            "idManufacturer = " + $"{product.idManufacturer}," +
            "idProduct_type = " + $"'{product.idProduct_type}'" +
            "where anime_shop.product.idproduct =" + $"{ product.IdProduct + 1}";




            cmd.Connection = conn;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
