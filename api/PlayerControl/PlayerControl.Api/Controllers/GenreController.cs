using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayerControl.Api.Security;
using PlayerControl.Application.UseCases.Genres.Commands;
using PlayerControl.Application.UseCases.Genres.Models;
using PlayerControl.Application.UseCases.Genres.Queries;

namespace PlayerControl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = Roles.Admin)]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GenreViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] CreateGenreCommand request)
        {
            var result = await _mediator.Send(request);
            return CreatedAtAction(nameof(Create), result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(GenreViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [Authorize(Roles = $"{Roles.Admin},{Roles.User}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetGenreQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            _ = await _mediator.Send(new DeleteGenreCommand(id));
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(GenreViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGenreApiInputModel request)
        {
            var result = await _mediator.Send(new UpdateGenreCommand(id, request.Name, request.IsActive, request.CategoryIds));
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GenreViewModel), StatusCodes.Status200OK)]
        [Authorize(Roles = $"{Roles.Admin},{Roles.User}")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new ListGenreQuery());
            return Ok(result);
        }
    }
}
