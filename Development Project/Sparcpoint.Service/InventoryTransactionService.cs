using Sparcpoint.Inventory.Abstractions;
using Sparcpoint.Inventory.Models;
using Sparcpoint.Service.Abstractions;

namespace Sparcpoint.Service;

public class InventoryTransactionService : BaseService<InventoryTransaction>
{
    public InventoryTransactionService(IRepository<InventoryTransaction> repo) : base(repo)
    {
    }
}