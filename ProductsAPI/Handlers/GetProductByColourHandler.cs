using ProductsAPI.Models;
using ProductsAPI.Queries;
using ProductsAPI.Repositories;
using MediatR;

namespace ProductsAPI.Handlers
{
    public class GetProductByColourHandler : IRequestHandler<GetProductByColourQuery, List<Product>>
    {
        private readonly IProductRepository _ProductRepository;

        public GetProductByColourHandler(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<List<Product>> Handle(GetProductByColourQuery query, CancellationToken cancellationToken)
        {
            return await _ProductRepository.GetProductByColourAsync(query.Colour);
        }
    }
}