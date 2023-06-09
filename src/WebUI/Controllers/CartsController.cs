using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Cart.Commands.AddProductToCartCommand;
using OnlineStore.Application.Cart.Queries;
using OnlineStore.Application.Common.Models;

namespace OnlineStore.WebUI.Controllers;

[Route("api/v1/[controller]")]
public class CartsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<CartDto>>> GetCartsWithPagination([FromQuery] GetCartsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("info")]
    public async Task<ActionResult<CartDto>> GetCartInfo([FromQuery] GetCartInfoQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost("add-product")]
    public async Task<ActionResult<int>> AddProductToCart(AddProductToCartCommand command)
    {
        return await Mediator.Send(command);
    }
}