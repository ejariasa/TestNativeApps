using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductTest.Common.Interfaces;
using ProductTest.Common.Models;
using ProductTest.Common.Responses;
using ProductTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.Business
{
    public class User : IUser
    {
        private ProductTestDbContext ProductTestDbContext;
        private readonly IMapper Mapper;

        public User(ProductTestDbContext context, IMapper mapper)
        {
            ProductTestDbContext = context;
            Mapper = mapper;
        }
        public  bool IsLogged(string username, string password)
        {
            if (password != null && username != null)
            {
                try
                {
                    var user =  ProductTestDbContext.Users
                        .Where(x => x.Username == username && x.Password == password)
                        .FirstOrDefault();
                    if (user != null)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
