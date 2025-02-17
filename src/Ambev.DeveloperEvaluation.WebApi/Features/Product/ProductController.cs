using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.ListProduct;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.ListProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public Task<IActionResult> Create([FromBody] CreateProductRequest request, CancellationToken cancellationToken) =>
            ValidatedRequest(
                new CreateProductRequestValidator(),
                request,
                async (product) =>
                {
                    var command = _mapper.Map<CreateProductCommand>(product);
                    var response = await _mediator.Send(command, cancellationToken);

                    if (response.IsError) return HandlingError(response.FirstError);

                    return Created(string.Empty, _mapper.Map<CreateProductResponse>(response.Value));
                },
                cancellationToken
            );

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public Task<IActionResult> Update(int id, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            return ValidatedRequest(
                new UpdateProductRequestValidator(),
                request,
                async (product) =>
                {
                    var command = _mapper.Map<UpdateProductCommand>(product);
                    var response = await _mediator.Send(command, cancellationToken);

                    if (response.IsError) return HandlingError(response.FirstError);

                    return NoContent();
                },
                cancellationToken
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public Task<IActionResult> Get(int id, CancellationToken cancellationToken) =>
            ValidatedRequest(
                new GetProductRequestValidator(),
                new GetProductRequest(id),
                async (product) =>
                {
                    var command = _mapper.Map<GetProductQuery>(product);
                    var response = await _mediator.Send(command, cancellationToken);

                    if (response.IsError) return HandlingError(response.FirstError);

                    return Ok(_mapper.Map<GetProductResponse>(response.Value));
                },
                cancellationToken
            );

        [HttpGet()]
        [ProducesResponseType(typeof(ApiResponseWithData<ListProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public Task<IActionResult> List([FromQuery]string? category, CancellationToken cancellationToken) =>
            ValidatedRequest(
                new ListProductRequestValidator(),
                category is null ? new ListProductRequest() : new ListProductRequest(category),
                async (product) =>
                {
                    var command = _mapper.Map<ListProductQuery>(product);
                    var response = await _mediator.Send(command, cancellationToken);

                    if (response.IsError) return HandlingError(response.FirstError);

                    return Ok(response.Value.Select(product=>_mapper.Map<ListProductResponse>(product)));
                },
                cancellationToken
            );


    }
}
