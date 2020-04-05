using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Categories
    {
        public int Id;
        public string Name;

        public Categories(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
