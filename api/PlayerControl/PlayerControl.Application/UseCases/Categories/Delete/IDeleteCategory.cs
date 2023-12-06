using MediatR;
using PlayerControl.Application.UseCases.Categories.Common;

namespace PlayerControl.Application.UseCases.Categories.Delete
{
    public interface IDeleteCategory : IRequestHandler<DeleteCategoryRequest, CategoryResponseModel>
    {
    }
}
