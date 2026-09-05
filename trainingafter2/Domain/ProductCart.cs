using trainingafter2.Domain.Interface;

namespace trainingafter2.Domain
{
    public class ProductCart
    {
        private string id;
        private Product product;
        private int quantity;

        public ProductCart() { }
        public ProductCart(string id, Product product, int quantity)
        {
            this.id = id;
            this.product = product;
            this.quantity = quantity;
        }
        public int Quantity()
        {
            return quantity;
        }
        public bool IsQuantityOverStock()
        {
            return quantity > product.Stock();
        }
        public Product Product()
        {
            return product;
        }
        public bool isProductNearExpiry()
        {
            return product.IsNearExpiry();
        }
        public decimal CalculateTotalPrice(DiscountCalculator discount)
        {   
            var price_discout = discount.Calculate(product);
            return price_discout * quantity;
        }
        public string ProductName()
        {
            return product.Name();
        }
    }
}
