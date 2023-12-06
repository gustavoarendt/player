using MediatR;
using PlayerControl.Application.UseCases.Categories.Common;

namespace PlayerControl.Application.UseCases.Categories.Create
{
    public interface ICreateCategory : IRequestHandler<CreateCategoryRequest, CategoryResponseModel>
    {
    }
}
