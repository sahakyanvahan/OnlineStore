using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Cart.Queries;
using OnlineStore.Application.Common.Models;

namespace Api.Controllers;

public class CartsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<CartDto>>> GetCartsWithPagination([FromQuery] GetCartsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}
