using Azure;
using Microsoft.AspNetCore.Mvc;
using ProductTest.Common.Interfaces;
using ProductTest.Common.Models;
using ProductTest.Common.Responses;
using ProductTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProduct ProductManager;
        public ProductController(IProduct productManager)
        {
            this.ProductManager = productManager;
        }
       

        [HttpGet]
        public List<ProductModel> GetAll()
        {
            var result = ProductManager.GetAll();
            if (result.Result != null && result.Result.Count > 0)
            {
                return result.Result.DataList;
            }
            return null;
        }

        [HttpDelete("{id}")]
        public int Delete(Guid id)
        {
            return this.ProductManager.Delete(id);
        }

        [HttpGet("{name}")]
        public List<ProductModel> GetByName(string name)
        {
            var result = ProductManager.GetByName(name);
            if (result.Result != null && result.Result.Count > 0)
            {
                return result.Result.DataList;
            }
            return null;
        }

        [HttpPost]
        [Route("getbyrange")]
        public List<ProductModel> GetByPriceRange([FromBody] ProductParameter parameters)
        {
            var result = ProductManager.GetByPrice(parameters.MinPrice, parameters.MaxPrice);
            if (result.Result != null && result.Result.Count > 0)
            {
                return result.Result.DataList;
            }
            return null;
        }

        
        [HttpPost("item")]
        public async Task<Common.Responses.Result<ProductModel>> Save([FromBody, Required] ProductModel request)
        {
            return await this.ProductManager.Save(request);
        }
    }
}
