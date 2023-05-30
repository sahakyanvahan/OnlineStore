using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Cart.Commands.AddProductToCartCommand;
using OnlineStore.Application.Cart.Queries;
using OnlineStore.Application.Common.Models;

namespace OnlineStore.WebUI.Controllers.V2;

[Route("api/v2/[controller]")]
public class CartsController : ApiControllerBase
{
    public async Task<ActionResult<PaginatedList<CartDto>>> GetCartInfoV2([FromQuery] GetCartsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}