using MediatR;
using PlayerControl.Application.UseCases.Categories.Common;

namespace PlayerControl.Application.UseCases.Categories.Update
{
    public record UpdateCategoryRequest(Guid Id, string? Name, string? Description, bool? IsActive) : IRequest<CategoryResponseModel>
    {
    }
}
