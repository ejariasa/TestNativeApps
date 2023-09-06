using ProductTest.Common.Models;
using ProductTest.Common.Responses;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace ProductTest.Common.Interfaces
{
    public interface IProduct
    {
        public  Task<Result<ProductModel>> Save(ProductModel product);
        public int Delete(Guid productId);
        public  Task<ListResult<ProductModel>> GetAll();
        public  Task<ListResult<ProductModel>> GetByName(string name);
        public  Task<ListResult<ProductModel>> GetByPrice(decimal minPrice, decimal maxPrice);
    }
}
