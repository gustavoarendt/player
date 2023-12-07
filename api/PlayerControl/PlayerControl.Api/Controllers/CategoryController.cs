using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayerControl.Application.UseCases.Categories.Common;
using PlayerControl.Application.UseCases.Categories.Create;
using PlayerControl.Application.UseCases.Categories.Delete;
using PlayerControl.Application.UseCases.Categories.Get;
using PlayerControl.Application.UseCases.Categories.Update;

namespace PlayerControl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            var result = await _mediator.Send(request);
            return CreatedAtAction(nameof(Create), result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CategoryResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetCategoryRequest(id));
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            _ = await _mediator.Send(new DeleteCategoryRequest(id));
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(CategoryResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
