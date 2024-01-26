using ProductsAPI.Models;
using MediatR;

namespace ProductsAPI.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Colour { get; set; }

        public UpdateProductCommand(int id, string name, decimal price, string colour)
        {
            Id = id;
            Name = name;
            Price = price;
            Colour = colour;
        }
    }
}