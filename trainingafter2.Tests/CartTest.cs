using trainingafter2.Domain;
using trainingafter2.Domain.Interface;

namespace trainingafter2.Tests;

public class CartTest
{
    [Fact]
    public void Subtotal_ShouldReturnCorrectTotal_WhenAllProductsAreInStock()
    {
        // Arrange
        var product1 = new Product("P1", "Apple", 100, 10,false);
        var product2 = new Product("P2", "Banana", 200, 20,false);

        var productCart1 = new ProductCart("PC1", product1, 2);
        var productCart2 = new ProductCart("PC2", product2, 3);

        var cart = new Cart("C1");
        cart.AddProductToCart(productCart1);
        cart.AddProductToCart(productCart2);
        
        var rules = new List<IDiscountRule>
        {
            new NearExpiryDiscount(),
        };
        var discount = new DiscountCalculator(rules);

        // Act
        var result = cart.Subtotal(discount);

        // Assert
        Assert.Equal(800, result);
    }
    [Fact]
    public void Subtotal_ShouldThrowException_WhenProductExceedsStock()
    {
        // Arrange
        var product = new Product("P1", "Apple", 100, 5,false);

        // Cart muốn mua 10 nhưng stock chỉ có 5
        var productCart = new ProductCart("PC1", product, 10);

        var cart = new Cart("C1");
        cart.AddProductToCart(productCart);

        var rules = new List<IDiscountRule>
        {
            new NearExpiryDiscount(),
        };
        var discount = new DiscountCalculator(rules);

        // Act
        var exception = Assert.Throws<Exception>(
            () => cart.Subtotal(discount)
        );

        // Assert
        Assert.Contains("Apple", exception.Message);
    }
}
