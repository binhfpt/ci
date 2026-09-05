namespace trainingafter2.Domain.Interface
{
    public interface IDiscountRule
    {
        bool IsApplicable(Product product);
        decimal Calculate(decimal price);
    }
    public class NearExpiryDiscount : IDiscountRule
    {
        public bool IsApplicable(Product product)
        {
            return product.IsNearExpiry();
        }

        public decimal Calculate(decimal price)
        {
            return price * 0.3m;
        }
    }
}
