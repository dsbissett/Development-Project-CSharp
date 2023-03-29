using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Inventory.Models;
using Sparcpoint.Service.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryTransactionsController : ControllerBase<InventoryTransaction>
    {
        public InventoryTransactionsController(IService<InventoryTransaction> service) : base(service)
        {
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<InventoryTransaction>), 200)]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(InventoryTransaction), 200)]
        public override async Task<IActionResult> GetById(int id)
        {
            return await base.GetById(id);
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(InventoryTransaction), 200)]
        public override async Task<IActionResult> Update(InventoryTransaction entity)
        {
            return await base.Update(entity);
        }
    }
}
