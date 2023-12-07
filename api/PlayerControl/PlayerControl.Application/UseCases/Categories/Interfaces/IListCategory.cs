using MediatR;
using PlayerControl.Application.UseCases.Categories.Models;
using PlayerControl.Application.UseCases.Categories.Queries;

namespace PlayerControl.Application.UseCases.Categories.Interfaces
{
    public interface IListCategory : IRequestHandler<ListCategoryQuery, IReadOnlyCollection<CategoryResponseViewModel>>
    {
    }
}
