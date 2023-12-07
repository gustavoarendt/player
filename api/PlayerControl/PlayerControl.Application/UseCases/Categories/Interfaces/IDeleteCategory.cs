using MediatR;
using PlayerControl.Application.UseCases.Categories.Commands;
using PlayerControl.Application.UseCases.Categories.Models;

namespace PlayerControl.Application.UseCases.Categories.Interfaces
{
    public interface IDeleteCategory : IRequestHandler<DeleteCategoryCommand, CategoryResponseViewModel>
    {
    }
}
