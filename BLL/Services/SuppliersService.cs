using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Gateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class SuppliersService
    {
        private SuppliersGateway _gateway;
        public SuppliersService()
        {
            _gateway = new SuppliersGateway();
        }
        public IEnumerable<string> GetSuppliersByCategory(int categoryId)   //2 query
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Suppliers, SuppliersDTO>()).CreateMapper();
            var list = mapper.Map<IEnumerable<Suppliers>, IEnumerable<SuppliersDTO>>(_gateway.GetSuppliersByCategory(categoryId));
            
            var resultList = new List<string>();
            foreach(var x in list)
            {
                resultList.Add(x.Name);
            }
            return resultList;
        }
        public IEnumerable<string> GetSuppliersByMaxCategories(ref int counted) //4 query
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Suppliers, SuppliersDTO>()).CreateMapper();
            var list = mapper.Map<IEnumerable<Suppliers>, IEnumerable<SuppliersDTO>>(_gateway.GetSuppliersByMaxCategory(ref counted));

            var resultList = new List<string>();
            foreach (var x in list)
            {
                resultList.Add(x.Name);
            }
            return resultList;
        }
        public IEnumerable<string> GetSuppliersAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Suppliers, SuppliersDTO>()).CreateMapper();
            var list = mapper.Map<IEnumerable<Suppliers>, IEnumerable<SuppliersDTO>>(_gateway.GetAll());

            var resultList = new List<string>();
            foreach (var x in list)
            {
                resultList.Add(x.Name);
            }
            return resultList;
        }
        public string GetById(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Suppliers, SuppliersDTO>()).CreateMapper();
            return mapper.Map<Suppliers, SuppliersDTO>(_gateway.GetById(id)).Name;
        }
    }
}
