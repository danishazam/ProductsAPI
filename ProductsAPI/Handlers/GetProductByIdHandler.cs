using ProductsAPI.Models;
using ProductsAPI.Queries;
using ProductsAPI.Repositories;
using MediatR;

namespace ProductsAPI.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _ProductRepository;

        public GetProductByIdHandler(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _ProductRepository.GetProductByIdAsync(query.Id);
        }
    }
}