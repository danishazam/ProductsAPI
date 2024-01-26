using ProductsAPI.Models;
using MediatR;

namespace ProductsAPI.Queries
{
    public class GetProductListQuery : IRequest<List<Product>>
    {
    }
}
