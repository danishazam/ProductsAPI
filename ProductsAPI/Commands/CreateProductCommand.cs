using ProductsAPI.Models;
using MediatR;

namespace ProductsAPI.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Colour { get; set; }

        public CreateProductCommand(string name, decimal price, string colour)
        {
            Name = name;
            Price = price;
            Colour = colour;            
        }
    }
}