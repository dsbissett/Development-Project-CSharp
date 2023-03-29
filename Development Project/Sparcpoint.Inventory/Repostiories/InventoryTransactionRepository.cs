using Microsoft.EntityFrameworkCore;
using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;

namespace Sparcpoint.Inventory.Repostiories;

public class InventoryTransactionRepository : RepositoryBase<InventoryTransaction>
{
    public InventoryTransactionRepository(DbContext context) : base(context)
    {
    }
}