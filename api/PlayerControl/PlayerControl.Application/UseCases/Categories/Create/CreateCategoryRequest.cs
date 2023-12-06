using MediatR;
using PlayerControl.Application.UseCases.Categories.Common;

namespace PlayerControl.Application.UseCases.Categories.Create
{
    public record CreateCategoryRequest(string Name, string Description) : IRequest<CategoryResponseModel>
    {
    }
}
