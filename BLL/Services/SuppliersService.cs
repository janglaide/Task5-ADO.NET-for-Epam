using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Gateways;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BLL.Services
{
    public class SuppliersService : IService<SuppliersDTO>
    {
        private SuppliersGateway _gateway;
        public SuppliersService()
        {
            _gateway = new SuppliersGateway();
        }
        public IEnumerable<SuppliersDTO> GetAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Suppliers, SuppliersDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Suppliers>, IEnumerable<SuppliersDTO>>(_gateway.GetAll());
        }
        public IEnumerable<string> GetSuppliersByCategory(int categoryId)   //2 query
        {
            var suppliers = GetAll();

            var productService = new ProductsService();
            var products = productService.GetAll();

            var categoryService = new CategoriesService();
            var categories = categoryService.GetAll();

            var list = suppliers
                .Join(products, s => s.Id, p => p.SupplierId,
                (s, p) => new { catId = p.CategoryId, supName = s.Name })
                .Join(categories, sp => sp.catId, c => c.Id,
                (sp, c) => new { categId = c.Id, supplierName = sp.supName })
                .Where(x => x.categId == categoryId).Distinct();

            var resultList = new List<string>();
            foreach(var x in list)
            {
                resultList.Add(x.supplierName);
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
        public IEnumerable<string> GetAllNames()
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
