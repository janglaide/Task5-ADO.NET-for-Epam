using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Gateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ProductsService
    {
        private ProductsGateway _gateway;
        public ProductsService()
        {
            _gateway = new ProductsGateway();
        }
        public IEnumerable<string> GetProductsAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Products, ProductsDTO>()).CreateMapper();
            var list = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(_gateway.GetAll());

            var resultList = new List<string>();
            foreach (var x in list)
            {
                resultList.Add(x.Name);
            }
            return resultList;
        }
        public IEnumerable<string> GetProductsByCategory(int categoryId)    //1 query
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Products, ProductsDTO>()).CreateMapper();
            var list = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(_gateway.GetProductsByCategory(categoryId));

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
            var list = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(_gateway.GetProductsBySupplier(supplierId));

            var resultList = new List<string>();
            foreach (var x in list)
            {
                resultList.Add(x.Name);
            }
            return resultList;
        }
    }
}
