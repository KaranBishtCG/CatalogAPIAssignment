using Catalog.Api.Models;

namespace Catalog.Api.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly Dictionary<int, Product> _products = new();
    private int _nextId = 1;
    private readonly object _lock = new();

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        lock (_lock)
        {
            return Task.FromResult(_products.Values.AsEnumerable());
        }
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        lock (_lock)
        {
            _products.TryGetValue(id, out var product);
            return Task.FromResult(product);
        }
    }

    public Task<Product> CreateAsync(CreateProductDto dto)
    {
        lock (_lock)
        {
            var product = new Product(_nextId++, dto.Name, dto.Price, dto.Category,dto.Description);
            _products[product.Id] = product;
            return Task.FromResult(product);
        }
    }

    public Task<Product?> UpdateAsync(int id, CreateProductDto dto)
    {
        lock (_lock)
        {
            if (!_products.ContainsKey(id))
            {
                return Task.FromResult<Product?>(null);
            }

            var updated = new Product(id, dto.Name, dto.Price, dto.Category, dto.Description);
            _products[id] = updated;
            return Task.FromResult<Product?>(updated);
        }
    }

    public Task<bool> DeleteAsync(int id)
    {
        lock (_lock)
        {
            return Task.FromResult(_products.Remove(id));
        }
    }
}