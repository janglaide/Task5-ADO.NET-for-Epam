using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Gateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CategoriesService
    {
        private CategoriesGateway _gateway;
        public CategoriesService()
        {
            _gateway = new CategoriesGateway();
        }
        public string GetById(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Categories, CategoriesDTO>()).CreateMapper();
            return mapper.Map<Categories, CategoriesDTO>(_gateway.GetById(id)).Name;
        }
        public IEnumerable<string> GetCategoriesAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Categories, CategoriesDTO>()).CreateMapper();
            var tmp = _gateway.GetAll();
            var list = mapper.Map<IEnumerable<Categories>, IEnumerable<CategoriesDTO>>(tmp);

            var resultList = new List<string>();
            foreach (var x in list)
            {
                resultList.Add(x.Name);
            }
            return resultList;
        }
    }
}
