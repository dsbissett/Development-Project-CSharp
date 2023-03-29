using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Inventory.Models;
using Sparcpoint.Service.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributesController : ControllerBase<ProductAttribute>
    {
        public ProductAttributesController(IService<ProductAttribute> service) : base(service)
        {
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ProductAttribute>), 200)]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductAttribute), 200)]
        public override async Task<IActionResult> GetById(int id)
        {
            return await base.GetById(id);
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductAttribute), 200)]
        public override async Task<IActionResult> Update(ProductAttribute entity)
        {
            return await base.Update(entity);
        }
    }
}
