using MySql.Data.MySqlClient;
using NoC_lab1.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NoC_lab1.DB
{
    public class KorzinaRepository : IRepository<Korzinka>
    {

        private MySqlConnection conn;



        public KorzinaRepository()
        {
            conn = DBcon.GetDBConnection();
        }


        public void Create(Korzinka item)
        {
            throw new NotImplementedException();
        }

        public void Delete( int idOrder, int idProduct)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            string sql = $"delete from `shoping_cart` where idOrder = {idOrder} and idProduct = {idProduct};";

            cmd.Connection = conn;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(Korzinka item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Korzinka Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Korzinka> GetSome(IEnumerable<int> ids)
        {
            conn.Open();
            string sql = $"Select * from `shoping_cart` order by shoping_cart.idOrder desc limit 10";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            List<Korzinka> korzin = new List<Korzinka>();

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Korzinka k = new Korzinka();
                        k.IdOrder = int.Parse(reader.GetString(0));
                        k.IdProduct = int.Parse(reader.GetString(1));
                        korzin.Add(k);
                    }
                }
            }
            conn.Close();
            return korzin;
        }



        public void Update(Korzinka item)
        {
            throw new NotImplementedException();
        }


    }
}
