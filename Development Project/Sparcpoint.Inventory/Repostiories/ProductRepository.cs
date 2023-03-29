using Microsoft.EntityFrameworkCore;
using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;

namespace Sparcpoint.Inventory.Repostiories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
