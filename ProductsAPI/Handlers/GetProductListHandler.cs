using ProductsAPI.Models;
using ProductsAPI.Queries;
using ProductsAPI.Repositories;
using MediatR;

namespace ProductsAPI.Handlers
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<Product>>
    {
        private readonly IProductRepository _ProductRepository;

        public GetProductListHandler(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<List<Product>> Handle(GetProductListQuery query, CancellationToken cancellationToken)
        {
            return await _ProductRepository.GetProductListAsync();
        }
    }
}