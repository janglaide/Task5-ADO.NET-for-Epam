using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Products
    {
        public int Id;
        public string Name;
        public int CategoryId;
        public int SupplierId;
        public Products(int id, string name, int catId, int supId)
        {
            Id = id;
            Name = name;
            CategoryId = catId;
            SupplierId = supId;
        }
    }
}
