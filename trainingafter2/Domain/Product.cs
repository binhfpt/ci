using trainingafter2.Domain.Interface;

namespace trainingafter2.Domain
{
    public class Product
    {
        private string id;
        private string name ;
        private decimal price;
        private int stock;
        private bool isNearExpiry;
        public Product() { }
        public Product(string id, string name, decimal price, int stock,bool isNear)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.stock = stock;
            this.isNearExpiry = isNear;
        }
        public string Name()
        {
            return name;
        }
        public bool IsOutOfStock()
        {
            return stock <= 0;
        }
        public int Stock()
        {
            return stock;
        }
        public bool IsNearExpiry()
        {
            return isNearExpiry;
        }
        public decimal Price()
        {
            return this.price;
        }


    }
}
