using System.Threading.Tasks;
using ProductsAPI.Controllers;
using ProductsAPI.Models;
using ProductsAPI.Commands;
using ProductsAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ProductsAPI.Commands;
using ProductsAPI.Controllers;
using ProductsAPI.Models;

namespace APITestProject
{
    public class ProductControllerTests
    {
        [Fact]
        public async Task CreateProduct_ReturnsOkResult()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new ProductsController(mockMediator.Object);

            var product = new Product
            {
                Name = "Test Product",
                Price = 19.99m,
                Colour = "Red"
            };

            // Act
            var result = await controller.AddProductAsync(product);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var productId = Assert.IsType<int>(okResult.Value);
            Assert.Equal(1, productId); 
        }

        [Fact]
        public async Task GetProduct_ReturnsOkResultWithProduct()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new ProductsController(mockMediator.Object);

            var getProductQuery = new GetProductByIdQuery
            {
                Id = 1
            };

            mockMediator.Setup(x => x.Send(It.IsAny<GetProductByIdQuery>(), default))
                        .ReturnsAsync(new Product { Id = 1, Name = "Test Product", Price = 19.99m });

            // Act
            var result = await controller.GetProductByIdAsync(getProductQuery.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var product = Assert.IsType<Product>(okResult.Value);
            Assert.Equal("Test Product", product.Name);
        }
    }
}