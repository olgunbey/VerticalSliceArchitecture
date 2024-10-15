using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VeritcalSliceArch.Features.Product.Dtos;
using VeritcalSliceArch.Infrastructure.Persistence;

namespace VeritcalSliceArch.Features.Product.Queries
{
    internal static class GetAllProduct
    {
        public class Query : IRequest<List<GetAllProductDto>>
        {
        }
        internal sealed class Handler : IRequestHandler<Query, List<GetAllProductDto>>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public Handler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }
            public async Task<List<GetAllProductDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _applicationDbContext.Products.Select(y => new GetAllProductDto()
                {
                    ProductName = y.ProductName,
                    Quantity = y.Quantity,
                }).ToListAsync();
            }
        }
    }
    public class GetAllProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/product/getallproduct", Handler).WithTags("Products");
        }

        public async static Task<IResult> Handler(IMediator mediator)
        {
            return Results.Ok(await mediator.Send(new GetAllProduct.Query()));
        }

    }
}
