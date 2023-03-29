using Microsoft.EntityFrameworkCore;
using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;

namespace Sparcpoint.Inventory.Repostiories;

public class CategoryRepository : RepositoryBase<Category>
{
    public CategoryRepository(DbContext context) : base(context)
    {
    }
}