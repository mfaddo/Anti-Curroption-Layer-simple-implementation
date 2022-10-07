using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCurroptionLayer.SimpleImplementation.Domain
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public int AvailableQty { get; private set; }
        public int Price { get; private set; }
        public string Name { get; private set; }

        public Product (Guid productId, int availableQty, int price, string name)
        {
            if (productId == default)
                throw new ArgumentNullException(
                nameof(ProductId),
                "Product id cannot be empty");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(
                nameof(Name),
                "Product name cannot be empty");
            ProductId = productId;
            AvailableQty = availableQty;
            Price = price;
            Name = name;
        }   
    }
}
