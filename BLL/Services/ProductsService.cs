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
    public class ProductsService : IService<ProductsDTO>
    {
        private ProductsGateway _gateway;
        public ProductsService()
        {
            _gateway = new ProductsGateway();
        }

        public IEnumerable<ProductsDTO> GetAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Products, ProductsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(_gateway.GetAll());
        }

        public IEnumerable<string> GetAllNames()
        {
            var list = GetAll();

            var resultList = new List<string>();
            foreach (var x in list)
            {
                resultList.Add(x.Name);
            }
            return resultList;
        }

        public string GetById(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Products, ProductsDTO>()).CreateMapper();
            return mapper.Map<Products, ProductsDTO>(_gateway.GetById(id)).Name;
        }

        public IEnumerable<string> GetProductsByCategory(int categoryId)    //1 query
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Products, ProductsDTO>()).CreateMapper();
            var products = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(_gateway.GetAll());

            var list = products.Where(x => x.CategoryId == categoryId);

            var resultList = new List<string>();
            foreach (var x in list)
            {
                resultList.Add(x.Name);
            }
            return resultList;
        }
        public IEnumerable<string> GetProductsBySupplier(int supplierId)    //3 query
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Products, ProductsDTO>()).CreateMapper();
            var products = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(_gateway.GetAll());

            var list = products.Where(x => x.SupplierId == supplierId);

            var resultList = new List<string>();
            foreach (var x in list)
            {
                resultList.Add(x.Name);
            }
            return resultList;
        }
    }
}
