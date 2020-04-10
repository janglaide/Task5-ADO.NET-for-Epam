using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Gateways
{
    public class ProductsGateway : IGateway<Products>
    {
        public IEnumerable<Products> GetAll()
        {
            var sqlExpression = "SELECT * FROM Products";

            var connection = new MyDBConnection();
            connection.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection.Connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            connection.CloseConnection();

            var list = new List<Products>();

            foreach (DataRow x in ds.Tables[0].Rows)
            {
                var id = x.ItemArray[0];
                var name = x.ItemArray[1];
                var catId = x.ItemArray[2];
                var supId = x.ItemArray[3];

                list.Add(new Products((int)id, (string)name, (int)catId, (int)supId));
            }
            return list;
        }

        public Products GetById(int id)
        {
            var connection = new MyDBConnection();
            connection.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = new SqlCommand("SELECT * FROM Products WHERE productId = @id",
                connection.Connection);

            var idParam = new SqlParameter("@id", id);
            adapter.SelectCommand.Parameters.Add(idParam);

            var ds = new DataSet();
            adapter.Fill(ds);

            connection.CloseConnection();

            return new Products(id, (string)ds.Tables[0].Rows[0].ItemArray[1], (int)ds.Tables[0].Rows[0].ItemArray[2],
                (int)ds.Tables[0].Rows[0].ItemArray[3]);
        }
    }
}
