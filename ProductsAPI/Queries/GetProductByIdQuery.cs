using ProductsAPI.Models;
using MediatR;

namespace ProductsAPI.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
