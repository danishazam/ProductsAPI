using ProductsAPI.Commands;
using ProductsAPI.Models;
using ProductsAPI.Queries;
using ProductsAPI.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;


namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Product>> GetProductListAsync()
        {
            var products = await mediator.Send(new GetProductListQuery());

            return products;
        }

        // GET api/Products/2
        [HttpGet("productId")]
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await mediator.Send(new GetProductByIdQuery() { Id = productId });

            return product;
        }

        // GET api/Products/red
        [HttpGet("colour")]
        public async Task<List<Product>> GetProductByColourAsync(string colour)
        {
            var product = await mediator.Send(new GetProductByColourQuery() { Colour = colour });

            return product;
        }

        // POST api/Products
        [HttpPost]
        public async Task<Product> AddProductAsync(Product product)
        {
            var newProduct = await mediator.Send(new CreateProductCommand(
                product.Name,
                product.Price,
                product.Colour));
            return newProduct;
        }

        // PUT api/Products/2
        [HttpPut]
        public async Task<int> UpdateProductAsync(Product product)
        {
            var isProductUpdated = await mediator.Send(new UpdateProductCommand(
               product.Id,
               product.Name,
               product.Price,
               product.Colour));
            return isProductUpdated;
        }

        // DELETE api/Products/2
        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int Id)
        {
            return await mediator.Send(new DeleteProductCommand() { Id = Id });
        }
    }
}
