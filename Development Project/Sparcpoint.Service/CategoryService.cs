using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;
using Sparcpoint.Service.Abstractions;

namespace Sparcpoint.Service;

public class CategoryService : BaseService<Category>
{
    public CategoryService(IRepository<Category> repo) : base(repo)
    {
    }
}