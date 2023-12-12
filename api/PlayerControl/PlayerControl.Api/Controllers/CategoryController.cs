using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayerControl.Api.Security;
using PlayerControl.Application.UseCases.Categories.Commands;
using PlayerControl.Application.UseCases.Categories.Models;
using PlayerControl.Application.UseCases.Categories.Queries;

namespace PlayerControl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = Roles.User)]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryResponseViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return CreatedAtAction(nameof(Create), result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CategoryResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [Authorize(Roles = $"{Roles.Admin},{Roles.User}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetCategoryQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            _ = await _mediator.Send(new DeleteCategoryCommand(id));
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(CategoryResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryApiInputModel request)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand(id, request.Name, request.Description, request.IsActive));
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(CategoryResponseViewModel), StatusCodes.Status200OK)]
        [Authorize(Roles = $"{Roles.Admin},{Roles.User}")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new ListCategoryQuery());
            return Ok(result);
        }
    }
}
