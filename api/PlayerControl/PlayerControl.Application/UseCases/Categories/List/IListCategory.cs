using MediatR;
using PlayerControl.Application.UseCases.Categories.Common;

namespace PlayerControl.Application.UseCases.Categories.List
{
    public interface IListCategory : IRequestHandler<ListCategoryRequest, IReadOnlyCollection<CategoryResponseModel>>
    {
    }
}
