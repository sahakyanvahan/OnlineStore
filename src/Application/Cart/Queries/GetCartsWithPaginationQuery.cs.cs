using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Application.Common.Models;
using OnlineStore.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace OnlineStore.Application.Cart.Queries;

public class GetCartsWithPaginationQuery: IRequest<PaginatedList<CartDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCartsWithPaginationQueryHandler : IRequestHandler<GetCartsWithPaginationQuery, PaginatedList<CartDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCartsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CartDto>> Handle(GetCartsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Carts
            .OrderBy(x => x.Name)
            .ProjectTo<CartDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}