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
            var sqlExpression = "SELECT * FROM Products WHERE productId = " + id.ToString();

            var connection = new MyDBConnection();
            connection.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection.Connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            connection.CloseConnection();

            return new Products(id, (string)ds.Tables[0].Rows[0].ItemArray[1], (int)ds.Tables[0].Rows[0].ItemArray[2],
                (int)ds.Tables[0].Rows[0].ItemArray[3]);
        }
        public IEnumerable<Products> GetProductsByCategory(int categoryId)  //1 query
        {
            string sqlExpression = "SELECT DISTINCT p.productId, p.name, p.categoryId, p.supplierId " +
                "FROM Products p " +
                "JOIN Categories c ON p.categoryId = c.categoryId " +
                "WHERE c.categoryId = " + categoryId;

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
        public IEnumerable<Products> GetProductsBySupplier(int supplierId)  //3 query
        {
            string sqlExpression = "SELECT DISTINCT p.productId, p.name, p.categoryId, p.supplierId " +
                "FROM Products p " +
                "JOIN Suppliers s ON p.supplierId = s.supplierId " +
                "WHERE s.supplierId = " + supplierId;

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
    }
}
