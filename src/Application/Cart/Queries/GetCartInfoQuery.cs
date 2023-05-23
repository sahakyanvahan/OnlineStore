using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.Application.Common.Models;
using OnlineStore.Application.Product.Queries;

namespace OnlineStore.Application.Cart.Queries;
public class GetCartInfoQuery : IRequest<CartDto>
{
    public int Id { get; set; }
}

public class GetCartInfoQueryHandler : IRequestHandler<GetCartInfoQuery, CartDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCartInfoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CartDto> Handle(GetCartInfoQuery request, CancellationToken cancellationToken)
    {
        return await _context.Carts
            .Where(x => x.Id == request.Id)
            .ProjectTo<CartDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}