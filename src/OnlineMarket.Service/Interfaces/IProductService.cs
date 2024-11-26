using OnlineMarket.Domain.Entities;
using OnlineMarket.Service.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Service.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(ProductCreationDto product);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
