using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Application.Common.Models;

namespace OnlineStore.Application.Category.Queries;

public class GetCategoriesWithPaginationQuery: IRequest<PaginatedList<CategoryDto>>
{
    public int CartId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCategoriesWithPaginationQueryHandler : IRequestHandler<GetCategoriesWithPaginationQuery, PaginatedList<CategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CategoryDto>> Handle(GetCategoriesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .OrderBy(x => x.Name)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}