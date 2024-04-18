

using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using DotNetDrinks.Controllers;
using DotNetDrinks.Models;
using DotNetDrinks.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class ProductsControllerTests
{
    [Fact]
    public async Task Edit_ReturnsViewResult_WithProductModel()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb").Options;
        var context = new ApplicationDbContext(options);
        var testProduct = new Product { Id = 1, Name = "Test Product" };
        context.Products.Add(testProduct);
        context.SaveChanges();
        var controller = new ProductsController(context);

        // Act
        var result = await controller.Edit(testProduct.Id);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<Product>(viewResult.ViewData.Model);
        Assert.Equal("Test Product", model.Name);
        Assert.Equal("Edit", viewResult.ViewName); // Ensure the view name "Edit" is returned
    }
}
