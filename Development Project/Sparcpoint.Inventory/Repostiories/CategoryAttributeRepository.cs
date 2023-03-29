using Microsoft.EntityFrameworkCore;
using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;

namespace Sparcpoint.Inventory.Repostiories;

public class CategoryAttributeRepository : RepositoryBase<CategoryAttribute>
{
    public CategoryAttributeRepository(DbContext context) : base(context)
    {
    }
}