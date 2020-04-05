using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Suppliers
    {
        public int Id;
        public string Name;
        public Suppliers(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
