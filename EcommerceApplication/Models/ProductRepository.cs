using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext apiDbContext;

        public ProductRepository(ApiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await apiDbContext.Products.ToListAsync();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await apiDbContext.Products.AddAsync(product);
            await apiDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
