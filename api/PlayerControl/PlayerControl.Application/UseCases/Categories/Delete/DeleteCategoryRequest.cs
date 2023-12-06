using MediatR;
using PlayerControl.Application.UseCases.Categories.Common;

namespace PlayerControl.Application.UseCases.Categories.Delete
{
    public record DeleteCategoryRequest(Guid Id) : IRequest<CategoryResponseModel>
    {
    }
}
