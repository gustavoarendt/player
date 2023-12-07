using MediatR;
using PlayerControl.Application.UseCases.Categories.Commands;
using PlayerControl.Application.UseCases.Categories.Models;

namespace PlayerControl.Application.UseCases.Categories.Interfaces
{
    public interface IUpdateCategory : IRequestHandler<UpdateCategoryCommand, CategoryResponseViewModel>
    {
    }
}
