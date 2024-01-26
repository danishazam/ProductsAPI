using ProductsAPI.Models;
using MediatR;

namespace ProductsAPI.Queries
{
    public class GetProductByColourQuery : IRequest<List<Product>>
    {
        public string Colour { get; set; }
    }
}
