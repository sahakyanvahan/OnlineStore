using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Category.Commands.CreateCategoryCommand;
using OnlineStore.Application.Category.Commands.DeleteCategoryCommand;
using OnlineStore.Application.Category.Commands.UpdateCategoryCommand;
using OnlineStore.Application.Category.Queries;
using OnlineStore.Application.Common.Models;
using OnlineStore.Application.Product.Commands.CreateProductCommand;
using OnlineStore.Application.Product.Commands.DeleteProductCommand;
using OnlineStore.Application.Product.Commands.UpdateProductCommand;
using OnlineStore.Application.Product.Queries;

namespace OnlineStore.WebUI.Controllers;

public class CategoriesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<CategoryDto>>> GetProductsWithPagination([FromQuery] GetCategoriesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCategoryCommand command)
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
        await Mediator.Send(new DeleteCategoryCommand(id));

        return NoContent();
    }
}