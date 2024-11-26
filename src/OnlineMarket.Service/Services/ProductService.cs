using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Data.DbContexts;
using OnlineMarket.Domain.Entities;
using OnlineMarket.Service.DTOs.Products;
using OnlineMarket.Service.Interfaces;

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

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _appDbContext.Products
                                              .OrderBy(p => p.Name)
                                              .ToListAsync(); 
            return products;
        }
    }
}
