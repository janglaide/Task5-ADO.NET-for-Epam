using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Gateways
{
    public interface IGateway<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
