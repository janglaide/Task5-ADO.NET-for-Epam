﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Gateways
{
    public class SuppliersGateway : IGateway<Suppliers>
    {
        public IEnumerable<Suppliers> GetAll()
        {
            var sqlExpression = "SELECT * FROM Suppliers";

            var connection = new MyDBConnection();
            connection.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection.Connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            connection.CloseConnection();

            var list = new List<Suppliers>();

            foreach (DataRow x in ds.Tables[0].Rows)
            {
                var id = x.ItemArray[0];
                var name = x.ItemArray[1];

                list.Add(new Suppliers((int)id, (string)name));
            }
            return list;
        }
        public Suppliers GetById(int id)
        {
            var connection = new MyDBConnection();
            connection.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = new SqlCommand("SELECT * FROM Suppliers WHERE supplierId = @id",
                connection.Connection);

            var idParam = new SqlParameter("@id", id);
            adapter.SelectCommand.Parameters.Add(idParam);

            var ds = new DataSet();
            adapter.Fill(ds);

            connection.CloseConnection();

            return new Suppliers(id, (string)ds.Tables[0].Rows[0].ItemArray[1]);
        }
        
        public IEnumerable<Suppliers> GetSuppliersByMaxCategory(ref int counted)    //4 query
        {
            var connection = new MyDBConnection();
            connection.OpenConnection();

            var sqlExpression = "SELECT v.supplier, s.supplierId, counted " +
                "FROM V5 v " +
                "JOIN Suppliers s ON v.supplier = s.name " +
                "ORDER BY counted DESC";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection.Connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            connection.CloseConnection();

            counted = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[1]);
            var list = new List<Suppliers>();

            foreach (DataRow x in ds.Tables[0].Rows)
            {
                if ((int)x.ItemArray[2] != counted)
                    break;
                var id = x.ItemArray[1];
                var name = x.ItemArray[0];

                list.Add(new Suppliers((int)id, (string)name));
            }
            return list;
        }
    }
}
