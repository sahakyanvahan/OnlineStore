using OnlineStore.Application.Common.Mappings;

namespace OnlineStore.Application.Category.Queries;

public class CategoryDto: IMapFrom<Domain.Entities.Category>
{
    public int Id { get; set; }

    public string? Name { get; set; }
}