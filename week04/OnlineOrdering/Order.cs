
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _products = new List<Product>();
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double GetTotalCost()
        {
            double totalProductCost = 0;
            foreach (var product in _products)
            {
                totalProductCost += product.GetTotalCost();
            }

            double shippingCost;
            if (_customer.GetAddress().IsInUSA())
            {
                shippingCost = 5;
            }
            else
            {
                shippingCost = 35;
            }
            return totalProductCost + shippingCost;
        }

        public string GetPackagingLabel()
        {
            string label = "Packaging Label:\n";
            foreach (var product in _products)
            {
                label += product.GetPackagingLabel() + "\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{_customer.GetCustomerInfo()}";
        }
    }
