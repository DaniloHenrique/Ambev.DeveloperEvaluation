using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
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

                    if (response.IsError) return HandlingError(response.FirstError);

                    return Created(string.Empty, _mapper.Map<CreateCartResponse>(response.Value));
                },
                cancellationToken
            );

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public Task<IActionResult> Put(int id, [FromBody]UpdateCartRequest request, CancellationToken cancellationToken = default)
        {
            request.Id = id;

            return ValidatedRequest(
                new UpdateCartValidator(),
                request,
                async (cart) =>
                {
                    var request = _mapper.Map<UpdateCartCommand>(cart);
                    var result = await _mediator.Send(request, cancellationToken);

                    if (result.IsError) return HandlingError(result.FirstError);

                    return NoContent();
                },
                cancellationToken
            );
        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(int id, CancellationToken cancellationToken = default) =>
        ValidatedRequest(
            new GetCartValidator(),
            new GetCartRequest(id),
            async (cart) =>
            {
                var command = _mapper.Map<GetCartQuery>(cart);
                var response = await _mediator.Send(command, cancellationToken);

                if (response.IsError) return HandlingError(response.FirstError);

                return Ok(_mapper.Map<GetCartResponse>(response.Value));
            },
            cancellationToken
        );
    }
}
