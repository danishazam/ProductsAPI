using ProductsAPI.Commands;
using ProductsAPI.Models;
using ProductsAPI.Repositories;
using MediatR;

namespace ProductsAPI.Handlers
{    
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _ProductRepository;

        public CreateProductHandler(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = command.Name,
                Price = command.Price,
                Colour = command.Colour
        };

            return await _ProductRepository.AddProductAsync(product);
        }
    }
}