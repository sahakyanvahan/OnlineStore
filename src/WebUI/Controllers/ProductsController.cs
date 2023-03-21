using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Common.Models;
using OnlineStore.Application.Product.Commands.CreateProductCommand;
using OnlineStore.Application.Product.Commands.DeleteProductCommand;
using OnlineStore.Application.Product.Commands.UpdateProductCommand;
using OnlineStore.Application.Product.Queries;

namespace OnlineStore.WebUI.Controllers;

public class ProductsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ProductDto>>> GetProductsWithPagination([FromQuery] GetProductWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}