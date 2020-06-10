using MySql.Data.MySqlClient;
using NoC_lab1.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NoC_lab1.DB
{
    public class OrderRepository : IRepository<Order>
    {
        private MySqlConnection conn;


        public OrderRepository()
        {
            conn = DBcon.GetDBConnection();
        }

        public void Create(Order order)
        {
            var id = ++GetSome(order.IdOrder).ToList().Last().IdOrder;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            string sql = $"INSERT INTO `anime_shop`.`Order`" +
            "(`idOrder`," +
            "`Delivery`," +
            "`Data`," +
            "`Price`," +
            "`idUser`)" +
            "VALUES" +
            $"({id}," +
            $"{order.Delivery}," +
            $"'{order.Data}'," +
            $"{ order.Price }," +
            $"{ order.idUser }); ";

            cmd.Connection = conn;
            cmd.CommandText = sql;

            int rowCount = cmd.ExecuteNonQuery();
            string result = "Обновлено строк = " + rowCount;
            conn.Close(); ;
        }

        public void Delete(Order item)
        {
            
        }

     

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }

        Order IRepository<Order>.Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetSome(IEnumerable<int> idorder)
        {
            conn.Open();
            string sql = $"Select * from anime_shop.order order by anime_shop.order.idOrder desc limit 10";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            List<Order> orders = new List<Order>();

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.IdOrder = int.Parse(reader.GetString(0));
                        order.Delivery = int.Parse(reader.GetString(1));
                        order.Data = reader.GetString(2);
                        order.Price = int.Parse(reader.GetString(3));
                        order.idUser = int.Parse(reader.GetString(4));
                        orders.Add(order);
                    }
                }
            }
            conn.Close();
            return orders;
        }
        public IEnumerable<Order> GetSome(int Orderid)
        {
            conn.Open();
            string sql = $"Select * from anime_shop.order order by anime_shop.order.idOrder desc limit 10";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            List<Order> orders = new List<Order>();

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.IdOrder = int.Parse(reader.GetString(0));
                        order.Delivery = int.Parse(reader.GetString(1));
                        order.Data = reader.GetString(2);
                        order.Price = int.Parse(reader.GetString(3));
                        order.idUser = int.Parse(reader.GetString(4));
                        orders.Add(order);
                    }
                }
            }
            conn.Close();
            return orders;
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
    }
}
