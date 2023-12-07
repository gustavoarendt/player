using MediatR;
using PlayerControl.Application.UseCases.Categories.Models;
using PlayerControl.Application.UseCases.Categories.Queries;

namespace PlayerControl.Application.UseCases.Categories.Interfaces
{
    public interface IGetCategory : IRequestHandler<GetCategoryQuery, CategoryResponseViewModel>
    {
    }
}
