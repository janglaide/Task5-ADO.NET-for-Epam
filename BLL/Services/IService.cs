using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<string> GetAllNames();
        string GetById(int id);
    }
}
