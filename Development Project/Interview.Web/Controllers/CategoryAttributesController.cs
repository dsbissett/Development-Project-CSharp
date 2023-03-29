using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Inventory.Models;
using Sparcpoint.Service.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAttributesController : ControllerBase<CategoryAttribute>
    {
        public CategoryAttributesController(IService<CategoryAttribute> service) : base(service)
        {
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<CategoryAttribute>), 200)]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(CategoryAttribute), 200)]
        public override async Task<IActionResult> GetById(int id)
        {
            return await base.GetById(id);
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(CategoryAttribute), 200)]
        public override async Task<IActionResult> Update(CategoryAttribute entity)
        {
            return await base.Update(entity);
        }
    }
}
