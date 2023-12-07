using MediatR;
using PlayerControl.Application.UseCases.Categories.Models;

namespace PlayerControl.Application.UseCases.Categories.Queries
{
    public record GetCategoryQuery(Guid Id) : IRequest<CategoryResponseViewModel>
    {
    }
}
