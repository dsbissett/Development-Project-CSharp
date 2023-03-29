using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;
using Sparcpoint.Service.Abstractions;

namespace Sparcpoint.Service;

public class ProductAttributeService : BaseService<ProductAttribute>
{
    public ProductAttributeService(IRepository<ProductAttribute> repo) : base(repo)
    {
    }
}