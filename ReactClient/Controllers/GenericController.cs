using System;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ReactClient.Controllers
{ 
    public abstract class GenericController<TBL, TDA> : ControllerBase where TBL : class where TDA : class
{
    private readonly IBLLService<TBL, TDA> _businessLogicService;

    protected GenericController(IBLLService<TBL, TDA> service)
    {
        _businessLogicService = service;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAllItems()
    {
        try
        {
            var services = await _businessLogicService.GetAllItems().ConfigureAwait(false);
            return Ok(JsonConvert.SerializeObject(services));
        }
        catch (Exception exception)
        {
            return StatusCode(500, exception.Message);
        }
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetItemById(int id)
    {
        try
        {
            var service = await _businessLogicService.GetItemById(id).ConfigureAwait(false);
            return service == null
                ? throw new Exception()
                : Ok(JsonConvert.SerializeObject(service));
        }
        catch
        {
            return NotFound($"{typeof(TBL).Name} with Id: {id} not found");
        }
    }

    [HttpPut]
    public virtual async Task<IActionResult> UpdateItem([FromBody] TBL item)
    {
        try
        {
            await _businessLogicService.Update(item).ConfigureAwait(false);
            return Ok($"{typeof(TBL).Name} have been successfully updated");
        }
        catch 
        {
            return NotFound($"{typeof(TBL).Name} not found");
        }
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> DeleteItem(int id)
    {
        try
        {
            await _businessLogicService.Delete(id).ConfigureAwait(false);
            return Ok($"{typeof(TBL).Name} have been successfully removed");
        }
        catch
        {
            return NotFound($"{typeof(TBL).Name} not found");
        }
    }

    [HttpPost]
    public virtual async Task<IActionResult> CreateItem([FromBody] TBL item)
    {
        try
        {
            await _businessLogicService.Create(item).ConfigureAwait(false);
            return Ok($"{typeof(TBL).Name} have been successfully created");
        }
        catch (Exception exception)
        {
            return StatusCode(500, exception.Message);
        }
    }
}
}