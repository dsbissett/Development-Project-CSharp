using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;
using Sparcpoint.Service.Abstractions;

namespace Sparcpoint.Service
{
    public class ProductService : BaseService<Product>
    {
        public ProductService(IRepository<Product> repo) : base(repo)
        {
        }
    }
}