using MediatR;
using PlayerControl.Application.UseCases.Categories.Common;

namespace PlayerControl.Application.UseCases.Categories.List
{
    public record ListCategoryRequest() : IRequest<IReadOnlyCollection<CategoryResponseModel>>
    {
    }
}
