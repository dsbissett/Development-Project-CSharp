using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;
using Sparcpoint.Service.Abstractions;

namespace Sparcpoint.Service;

public class CategoryAttributeService : BaseService<CategoryAttribute>
{
    public CategoryAttributeService(IRepository<CategoryAttribute> repo) : base(repo)
    {
    }
}