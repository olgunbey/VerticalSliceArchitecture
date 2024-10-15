using Carter;
using FluentValidation;
using MediatR;
using System.Web.Http;
using VeritcalSliceArch.Features.Product.Dtos;
using VeritcalSliceArch.Infrastructure.Persistence;

namespace VeritcalSliceArch.Features.Product.Commands
{
    internal static class CreateProduct
    {
        public class Query : IRequest<bool>
        {
            public CreateProductDto Product { get; set; }
        }

        internal sealed class Handler : IRequestHandler<Query, bool>
        {
            private IApplicationDbContext _context;
            public Handler(IApplicationDbContext applicationDbContext)
            {
                _context = applicationDbContext;
            }
            public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                var Product = new Domain.Entities.Product()
                {
                    ProductName = request.Product.Name,
                    CategoryID = request.Product.CategoryId,
                    Description = request.Product.Description,
                    Quantity = request.Product.Quantity,
                };
                _context.Products.Add(Product);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
        public sealed class ProductValidator : AbstractValidator<Domain.Entities.Product>
        {
            public ProductValidator()
            {
                RuleFor(y => y.Description).NotEmpty().MinimumLength(15).WithMessage("Minimum 15 karakter!!");
            }
        }
    }
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/product/createproduct", Handler).WithTags("Products").AddEndpointFilter<EndpointFilter>();
        }

        public static async Task<IResult> Handler([FromBody] CreateProductDto productDto, IMediator mediator, string zort)
        {
            await mediator.Send(new CreateProduct.Query());
            return Results.Ok(productDto);
        }
    }
    public sealed class EndpointFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var productDto = context.Arguments.FirstOrDefault(arg => arg is CreateProductDto) as CreateProductDto;

            if (productDto == null)
            {
                return Results.BadRequest(new { Message = "Invalid product data." });
            }
            var validator = new CreateProduct.ProductValidator();
            var validationResult = validator.Validate(new Domain.Entities.Product
            {
                Description = productDto.Description,
                Quantity = productDto.Quantity,
                CategoryID = productDto.CategoryId,
                ProductName = productDto.Name
            });

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return Results.BadRequest(new
                {
                    Message = "Validation failed.",
                    Errors = errors
                });
            }

            return await next(context);
        }
    }
}
