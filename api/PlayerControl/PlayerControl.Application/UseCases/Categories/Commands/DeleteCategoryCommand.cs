using MediatR;
using PlayerControl.Application.UseCases.Categories.Models;

namespace PlayerControl.Application.UseCases.Categories.Commands
{
    public record DeleteCategoryCommand(Guid Id) : IRequest<CategoryResponseViewModel>
    {
    }
}
