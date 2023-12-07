using MediatR;
using PlayerControl.Application.UseCases.Categories.Models;

namespace PlayerControl.Application.UseCases.Categories.Commands
{
    public record UpdateCategoryCommand(Guid Id, string? Name, string? Description, bool? IsActive) : IRequest<CategoryResponseViewModel>
    {
    }
}
