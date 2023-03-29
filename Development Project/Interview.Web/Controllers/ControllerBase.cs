using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Service.Abstractions;

namespace Interview.Web.Controllers;

public abstract class ControllerBase<T> : ControllerBase where T : class
{
    private readonly IService<T> service;

    protected ControllerBase(IService<T> service)
    {
        this.service = service;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        return this.Ok(await this.service.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public virtual async Task<IActionResult> GetById([FromRoute] int id)
    {
        return this.Ok(await this.service.GetAsync(id));
    }

    [HttpPut]
    public virtual async Task<IActionResult> Update(T entity)
    {
        return this.Ok(await this.service.UpdateAsync(entity));
    }
}