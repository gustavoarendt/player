using MediatR;
using PlayerControl.Application.UseCases.Categories.Common;

namespace PlayerControl.Application.UseCases.Categories.Get
{
    public record GetCategoryRequest(Guid Id) : IRequest<CategoryResponseModel>
    {
    }
}
