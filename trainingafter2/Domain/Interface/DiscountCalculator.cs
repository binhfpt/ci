namespace trainingafter2.Domain.Interface
{
    public class DiscountCalculator
    {
        private readonly IEnumerable<IDiscountRule> rules;

        public DiscountCalculator(IEnumerable<IDiscountRule> rules)
        {
            this.rules = rules;
        }

        public decimal Calculate(Product product)
        {
            var rule = rules.FirstOrDefault(r => r.IsApplicable(product));

            return rule == null
                ? product.Price()
                : rule.Calculate(product.Price());
        }
    }

    
}
