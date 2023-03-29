using Microsoft.EntityFrameworkCore;
using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;

namespace Sparcpoint.Inventory.Repostiories;

public class ProductAttributeRepository : RepositoryBase<ProductAttribute>
{
    public ProductAttributeRepository(DbContext context) : base(context)
    {
    }
}