using AutoMapper;
using ProductTest.Common.Models;
using ProductTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.Business.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<User, UserModel>();
            CreateMap<Category, CategoryModel>();
            CreateMap<ProductModel, Product>();
            CreateMap<UserModel, User>();
            CreateMap<CategoryModel, Category>();


        }
    }
}
