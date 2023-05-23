using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Cart.Commands.AddProductToCartCommand;
using OnlineStore.Application.Cart.Queries;
using OnlineStore.Application.Common.Models;

namespace OnlineStore.WebUI.Controllers;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class CartsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<CartDto>>> GetCartsWithPagination([FromQuery] GetCartsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("/info")]
    public async Task<ActionResult<CartDto>> GetCartInfo([FromQuery] GetCartInfoQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("/info")]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<PaginatedList<CartDto>>> GetCartInfoV2([FromQuery] GetCartsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost("/add-product")]
    public async Task<ActionResult<int>> AddProductToCart(AddProductToCartCommand command)
    {
        return await Mediator.Send(command);
    }
}