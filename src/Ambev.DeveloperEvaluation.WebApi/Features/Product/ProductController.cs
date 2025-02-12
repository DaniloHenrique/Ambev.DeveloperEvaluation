using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

                    return Created(string.Empty, _mapper.Map<CreateProductResponse>(response));
                },
                cancellationToken
            );

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public Task<IActionResult> Update([FromBody] UpdateProductRequest request, CancellationToken cancellationToken)=>
            ValidatedRequest(
                new UpdateProductRequestValidator(),
                request,
                async (product) =>
                {
                    var command = _mapper.Map<UpdateProductCommand>(product);
                    var response = await _mediator.Send(command, cancellationToken);

                    return Ok(_mapper.Map<UpdateProductResponse>(response));
                },
                cancellationToken
            );

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public Task<IActionResult> Update(int id, CancellationToken cancellationToken) =>
            ValidatedRequest(
                new GetProductRequestValidator(),
                new GetProductRequest(id),
                async (product) =>
                {
                    var command = _mapper.Map<GetProductCommand>(product);
                    var response = await _mediator.Send(command, cancellationToken);

                    return response is null
                        ? NotFound($"Product {id} not found")
                        : Ok(_mapper.Map<GetProductResponse>(response));
                },
                cancellationToken
            );


    }
}
