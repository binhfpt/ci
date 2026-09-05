using trainingafter2.Domain.Interface;

namespace trainingafter2.Domain
{
    public class Cart
    {
        private string id;
        private List<ProductCart> products = new List<ProductCart>();

        public Cart() {
        }

        public Cart(string id)
        {
            this.id = id;
        }
        public void AddProductToCart(ProductCart product)
        {
            products.Add(product);
        }

        public void RemoveProductFromCart(ProductCart product)
        {
            products.Remove(product);
        }
        
        public bool IsEmptyCart()
        {
            return products.Count == 0;
        }

        public bool IsProductOutOfStock()
        {
            foreach (var product in products)
            {
                if (product.IsQuantityOverStock())
                {
                    return true;
                }
            }
            return false;
        }
        
        public decimal Subtotal(DiscountCalculator discount)
        {
            var outOfStockList = new List<string>();
            decimal subtotal = 0;
            foreach (var product in products)
            {
                if (product.IsQuantityOverStock())
                {
                    outOfStockList.Add(product.ProductName());
                }
                subtotal += product.CalculateTotalPrice(discount);
            }
            if(outOfStockList.Count > 0)
            {
                throw new Exception("The following products are out of stock: " + string.Join(", ", outOfStockList));
            }
            return subtotal;
        }
    }
}
