//using MySql.Data.MySqlClient;
//using NoC_lab1.Entitys;
//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NoC_lab1.DB
//{
//    public class DBManager
//    {
//        public static List<Product> SelectProducts(MySqlConnection conn)
//        {
//            conn.Open();
//            string sql = $"Select * from Product limit 100";

//            // Создать объект Command.
//            MySqlCommand cmd = new MySqlCommand
//            {
//                Connection = conn,
//                CommandText = sql
//            };
//            List<Product> Products = new List<Product>();

//            using (DbDataReader reader = cmd.ExecuteReader())
//            {
//                if (reader.HasRows)
//                {

//                    while (reader.Read())
//                    {
//                        Product Product = new Product();
//                        Product.IdProduct = int.Parse(reader.GetString(0));
//                        Product.Name = reader.GetString(1);
//                        Product.Price = int.Parse(reader.GetString(2));
//                        Product.Quantity = int.Parse(reader.GetString(3));
//                        Product.info = reader.GetString(4);
//                        Product.idManufacturer = int.Parse(reader.GetString(5));
//                        Product.idProduct_type = int.Parse(reader.GetString(6));
//                        Products.Add(Product);
//                    }
//                }
//            }
//            conn.Close();
//            return Products;

//        }

//        public static List<Order> SelectOrders(MySqlConnection conn)
//        {
//            conn.Open();
//            string sql = $"Select * from anime_shop.order order by anime_shop.order.idOrder desc limit 10";
            
//            // Создать объект Command.
//            MySqlCommand cmd = new MySqlCommand
//            {
//                Connection = conn,
//                CommandText = sql
//            };
//            List<Order> orders = new List<Order>();

//            using (DbDataReader reader = cmd.ExecuteReader())
//            {
//                if (reader.HasRows)
//                {

//                    while (reader.Read())
//                    {
//                        Order order = new Order();
//                        order.IdOrder = int.Parse(reader.GetString(0));
//                        order.Delivery = int.Parse(reader.GetString(1));
//                        order.Data = reader.GetString(2);
//                        order.Price = int.Parse(reader.GetString(3));
//                        order.idUser = int.Parse(reader.GetString(4));
//                        orders.Add(order);
//                    }
//                }
//            }
//            conn.Close();
//            return orders;

//        }

//        public static void InsertOrder(MySqlConnection conn, Order order)
//        {
//            var a = SelectOrders(conn);
//            conn.Open();
//            MySqlCommand cmd = new MySqlCommand();
            
           
//            long id = ++a.FirstOrDefault().IdOrder;
//            string sql = $"INSERT INTO `anime_shop`.`Order`" +
//            "(`idOrder`," +
//            "`Delivery`," +
//            "`Data`," +
//            "`Price`," +
//            "`idUser`)" +
//            "VALUES" +
//            $"({id}," +
//            $"{order.Delivery}," +
//            $"'{order.Data}'," +
//            $"{ order.Price }," +
//            $"{ order.idUser }); ";

//            cmd.Connection = conn;
//            cmd.CommandText = sql;

//            int rowCount = cmd.ExecuteNonQuery();
//            string result = "Обновлено строк = " + rowCount;
//            conn.Close();
//        }

//        public static List<Korzinka> SelectKorzinkas(MySqlConnection conn)
//        {
//            conn.Open();
//            string sql = $"Select * from `shoping_cart` order by shoping_cart.idOrder desc limit 10";

//            // Создать объект Command.
//            MySqlCommand cmd = new MySqlCommand
//            {
//                Connection = conn,
//                CommandText = sql
//            };
//            List<Korzinka> korzin = new List<Korzinka>();

//            using (DbDataReader reader = cmd.ExecuteReader())
//            {
//                if (reader.HasRows)
//                {

//                    while (reader.Read())
//                    {
//                        Korzinka k = new Korzinka();
//                        k.IdOrder = int.Parse(reader.GetString(0));
//                        k.IdProduct = int.Parse(reader.GetString(1));
//                        korzin.Add(k);
//                    }
//                }
//            }
//            conn.Close();
//            return korzin;

//        }

//        public static void UpdateProduct(MySqlConnection conn, Product product)
//        {
//            conn.Open();
//            MySqlCommand cmd = new MySqlCommand();

//            long id = cmd.LastInsertedId;
//            string sql = $"UPDATE anime_shop.product " +
//            "set Name=" + $"'{product.Name}'," +
//            "Price = " + $"{product.Price}," +
//            "Quantity = " + $"'{product.Quantity}'," +
//            "info = " + $"'{product.info}'," +
//            "idManufacturer = " + $"{product.idManufacturer}," +
//            "idProduct_type = " + $"'{product.idProduct_type}'" +
//            "where anime_shop.product.idproduct =" + $"{ product.IdProduct + 1}";




//            cmd.Connection = conn;
//            cmd.CommandText = sql;

//            cmd.ExecuteNonQuery();
//            conn.Close();
//        }

//        public static void DeleteKorzina(MySqlConnection conn, int idOrder, int idProduct)
//        {
//            conn.Open();
//            MySqlCommand cmd = new MySqlCommand();
//            string sql = $"delete from `shoping_cart` where idOrder = {idOrder} and idProduct = {idProduct};";

//            cmd.Connection = conn;
//            cmd.CommandText = sql;

//            cmd.ExecuteNonQuery();
//            conn.Close();
//        }
//    }
//}
