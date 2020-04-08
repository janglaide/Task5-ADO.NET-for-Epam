using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Gateways
{
    public class CategoriesGateway : IGateway<Categories>
    {
        public IEnumerable<Categories> GetAll()
        {
            var sqlExpression = "SELECT * FROM Categories";

            var connection = new MyDBConnection();
            connection.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection.Connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            connection.CloseConnection();

            var list = new List<Categories>();

            foreach(DataRow x in ds.Tables[0].Rows)
            {
                var id = x.ItemArray[0];
                var name = x.ItemArray[1];

                list.Add(new Categories((int)id, (string)name));
            }
            return list;
        }

        public Categories GetById(int id)
        {
            var sqlExpression = "SELECT * FROM Categories WHERE categoryId = " + id.ToString();

            var connection = new MyDBConnection();
            connection.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection.Connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            connection.CloseConnection();

            return new Categories(id, ds.Tables[0].Rows[0].ItemArray[1].ToString());
        }
    }
}
