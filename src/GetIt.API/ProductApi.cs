using GetIt.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GetIt.API
{
    public static class ProductApi
    {
        public static void MapProductRoutes(this IEndpointRouteBuilder app)
        {
            app.MapGet("/products/getrecentlyaddedproducts", async ([FromQuery] int count, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetRecentlyAddedProducts(count));
                return result;
            });
        }
    }
}
