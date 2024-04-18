

using Xunit;
using Microsoft.AspNetCore.Mvc;
using DotNetDrinks.Controllers;
using DotNetDrinks.Models;
using DotNetDrinks.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        var model = Assert.IsInstanceOfType<Product>(viewResult.ViewData.Model);
        Assert.Equals("Test Product", model.Name);
        Assert.Equals("Edit", viewResult.ViewName); // Ensure the view name "Edit" is returned
    }


    [Fact]
    public async Task DeleteConfirmed_RemovesProduct_AndRedirects()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb").Options;
        var context = new ApplicationDbContext(options);
        var product = new Product { Id = 1, Name = "Test Product" };
        context.Products.Add(product);
        context.SaveChanges();
        var controller = new ProductsController(context);

        // Act
        var result = await controller.DeleteConfirmed(1);

        // Assert
        Assert.DoesNotContain(context.Products, p => p.Id == product.Id); // Check if the product is removed
        var redirectToActionResult = Assert.IsInstanceOfType<RedirectToActionResult>(result);
        Assert.Equals("Index", redirectToActionResult.ActionName); // Ensure redirection to Index action
    }

}
