using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayerControl.Api.Security;
using PlayerControl.Application.UseCases.Videos.Commands;
using PlayerControl.Application.UseCases.Videos.Models;
using PlayerControl.Application.UseCases.Videos.Queries;

namespace PlayerControl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = Roles.Admin)]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(VideoViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] CreateVideoCommand request)
        {
            var result = await _mediator.Send(request);
            return CreatedAtAction(nameof(Create), result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(VideoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [Authorize(Roles = $"{Roles.Admin},{Roles.User}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetVideoQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            _ = await _mediator.Send(new DeleteVideoCommand(id));
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(VideoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateVideoApiInputModel request)
        {
            var result = await _mediator.Send(new UpdateVideoCommand(id, request.Title, request.Description, request.Year, request.Duration, request.Rating, request.CategoryIds, request.GenreIds, request.Image, request.Media));
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(VideoViewModel), StatusCodes.Status200OK)]
        [Authorize(Roles = $"{Roles.Admin},{Roles.User}")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new ListVideoQuery());
            return Ok(result);
        }

        [HttpPost("{id:guid}/media/{type}")]
        [ProducesResponseType(typeof(VideoViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> UploadMedia([FromRoute] Guid id, [FromRoute] string type, [FromForm] UploadMediaApiInputModel request)
        {
            var input = request.ToUploadMediaInput(id, type);
            await _mediator.Send(input);
            return NoContent();
        }
    }
}
