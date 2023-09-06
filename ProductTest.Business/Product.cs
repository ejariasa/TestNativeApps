using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductTest.Common.Interfaces;
using ProductTest.Common.Models;
using ProductTest.Common.Responses;
using ProductTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductTest.Business
{
    public class Product : IProduct
    {
        private ProductTestDbContext ProductTestDbContext;
        private readonly IMapper Mapper;
        public Product(ProductTestDbContext context, IMapper mapper)
        {
            ProductTestDbContext = context;
            Mapper = mapper;
        }

        public int Delete(Guid productId)
        {
            ProductTestDbContext.Remove(productId);
            return ProductTestDbContext.SaveChanges();
        }

        public async Task<ListResult<ProductModel>> GetAll()
        {
            try
            {
                var list = await ProductTestDbContext.Products
             .Include(x => x.Category)
             .ToListAsync();
                return new ListResult<ProductModel>
                {
                    DataList = Mapper.Map<List<ProductModel>>(list),
                    Count = list.Count(),
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ListResult<ProductModel>
                {
                    DataList = null,
                    Count = 0,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Success = false,
                    ResponseReason = ex.ToString()
                };
            }

        }

        public async Task<ListResult<ProductModel>> GetByName(string name)
        {
            try
            {
                var list = await ProductTestDbContext.Products
                .Where(x => x.Name == name)
                .Include(x => x.Category)
                .ToListAsync();
                return new ListResult<ProductModel>
                {
                    DataList = Mapper.Map<List<ProductModel>>(list),
                    Count = list.Count(),
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ListResult<ProductModel>
                {
                    DataList = null,
                    Count = 0,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Success = false,
                    ResponseReason = ex.ToString()
                };
            }
        }

        public async Task<ListResult<ProductModel>> GetByPrice(decimal minPrice, decimal maxPrice)
        {
            try
            {
                var list = await ProductTestDbContext.Products
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .Include(x => x.Category)
                .ToListAsync();
                return new ListResult<ProductModel>
                {
                    DataList = Mapper.Map<List<ProductModel>>(list),
                    Count = list.Count(),
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ListResult<ProductModel>
                {
                    DataList = null,
                    Count = 0,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Success = false,
                    ResponseReason = ex.ToString()
                };
            }
        }

        public async Task<Result<ProductModel>> Save(ProductModel product)
        {
            try
            {
                var productToSave = Mapper.Map<ProductModel>(product);
                if (product.Id == null)
                {
                    productToSave.Id = Guid.NewGuid();
                    product.Active = true;
                    ProductTestDbContext.Add(productToSave);
                }
                else
                {
                    ProductTestDbContext.Update(productToSave);
                }
                await ProductTestDbContext.SaveChangesAsync();
                return new Result<ProductModel>
                {
                    Data = productToSave,
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                    Success = true
                };

            }
            catch (Exception ex)
            {
                return new Result<ProductModel>
                {
                    Data = null,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Success = false,
                    ResponseReason = ex.ToString()
                };
            }

        }
    }
}