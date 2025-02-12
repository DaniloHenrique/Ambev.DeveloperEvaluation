using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CartController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public Task<IActionResult> Create([FromBody] CreateCartRequest request, CancellationToken cancellationToken = default) =>
            ValidatedRequest(
                new CreateCartValidator(),
                request,
                async (cart) =>
                {
                    var command = _mapper.Map<CreateCartCommand>(cart);
                    var response = await _mediator.Send(command, cancellationToken);

                    return Created(string.Empty, _mapper.Map<CreateCartResponse>(response));
                }
            );
    }
}
