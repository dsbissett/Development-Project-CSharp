﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Sparcpoint.Inventory.Models;
using Sparcpoint.Service.Abstractions;

namespace Interview.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase<Product>
    {
        public ProductController(IService<Product> service) : base(service)
        {
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), 200)]
        public override async Task<IActionResult> GetById(int id)
        {
            return await base.GetById(id);
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), 200)]
        public override async Task<IActionResult> Update(Product entity)
        {
            return await base.Update(entity);
        }
    }
}
