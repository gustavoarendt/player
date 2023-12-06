using MediatR;
using PlayerControl.Application.UseCases.Categories.Common;

namespace PlayerControl.Application.UseCases.Categories.Get
{
    public interface IGetCategory : IRequestHandler<GetCategoryRequest, CategoryResponseModel>
    {
    }
}
