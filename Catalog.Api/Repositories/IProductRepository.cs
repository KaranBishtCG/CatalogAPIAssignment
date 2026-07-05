using Catalog.Api.Models;

namespace Catalog.Api.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(CreateProductDto dto);
    Task<Product?> UpdateAsync(int id, CreateProductDto dto);
    Task<bool> DeleteAsync(int id);
}