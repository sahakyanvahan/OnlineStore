using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using OnlineStore.Application.Category.Queries;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Application.Common.Models;
using OnlineStore.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace OnlineStore.Application.Product.Queries;

public class GetProductWithPaginationQuery : IRequest<PaginatedList<ProductDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

public class GetProductWithPaginationQueryHandler : IRequestHandler<GetProductWithPaginationQuery, 
    PaginatedList<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductDto>> Handle(GetProductWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .OrderBy(x => x.Name)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
