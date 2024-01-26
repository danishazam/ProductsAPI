using ProductsAPI.Commands;
using ProductsAPI.Repositories;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _ProductRepository;

        public UpdateProductHandler(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _ProductRepository.GetProductByIdAsync(command.Id);
            if (product == null)
                return default;

            product.Name = command.Name;
            product.Price = command.Price;
            product.Colour = command.Colour;
            
            return await _ProductRepository.UpdateProductAsync(product);
        }
    }
}