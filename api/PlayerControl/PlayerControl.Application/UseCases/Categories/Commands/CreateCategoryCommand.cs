using MediatR;
using PlayerControl.Application.UseCases.Categories.Models;

namespace PlayerControl.Application.UseCases.Categories.Commands
{
    public record CreateCategoryCommand(string Name, string Description) : IRequest<CategoryResponseViewModel>
    {
    }
}
