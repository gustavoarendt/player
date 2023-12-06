using MediatR;
using PlayerControl.Application.UseCases.Categories.Common;

namespace PlayerControl.Application.UseCases.Categories.Update
{
    public interface IUpdateCategory : IRequestHandler<UpdateCategoryRequest, CategoryResponseModel>
    {
    }
}
