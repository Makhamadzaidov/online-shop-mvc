using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Data.DbContexts;
using OnlineMarket.Domain.Entities;
using OnlineMarket.Service.Commons.Utils;
using OnlineMarket.Service.DTOs.Products;
using OnlineMarket.Service.Extensions;
using OnlineMarket.Service.Interfaces;
using System.Linq.Expressions;

namespace OnlineMarket.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public ProductService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<Product> CreateAsync(ProductCreationDto product)
        {
            var creationProduct = _mapper.Map<Product>(product);

            if (string.IsNullOrEmpty(product.Description))
                creationProduct.Description = "";

            var result = await _appDbContext.Products.AddAsync(creationProduct);
            await _appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<ProductViewDto>> GetAllAsync(Expression<Func<Product, bool>> expression = null, PaginationParams? @params = null)
        {
            var query = _appDbContext.Products.Include(p => p.Category).AsQueryable();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            var products = query
                .OrderBy(p => p.Name) // Optional: Order by Name
                .Select(p => new ProductViewDto()
                {
                    CategoryName = p.Category.Name,
                    Description = p.Description,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                })
                .ToPagedAsEnumerable(@params); // Apply pagination logic

            return products;
        }


    }
}
