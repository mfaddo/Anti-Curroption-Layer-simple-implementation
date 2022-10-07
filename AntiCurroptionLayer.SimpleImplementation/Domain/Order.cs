using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCurroptionLayer.SimpleImplementation.Domain
{
    public class Order
    {
      public Guid Id { get; private set; }
      public string Number { get; private set; }
      public Guid CustomerId { get; private set; }
      public decimal total { get; private set; }

      public List<OrderLine> orderLines { get; private set; }
        
      public Order(Guid id , Guid customerId)
        {
            if (id == default)
                throw new ArgumentNullException(
                nameof(Id),
                "Order id cannot be empty");
            Id = id;

            if (customerId == default)
                throw new ArgumentNullException(
                nameof(CustomerId),
                "Customer id cannot be empty");
            CustomerId = id;

            orderLines = new List<OrderLine>();
        }

        public void AddOrderLine(Guid productId , int Qty, IProductTranslator productTranslator)
        {
            var line = FindLine(productId);
            if(line ==null)
            {
                orderLines.Add(OrderLine.FromProduct(productId, Qty, productTranslator));
            }
            else
            {
                line.updateLineQty(Qty, productTranslator);
            }

            computeOrderTotal();
        }

        private OrderLine FindLine(Guid id)
           => orderLines.FirstOrDefault(x => x.Id == id);

        private void computeOrderTotal() => 
            total = orderLines.Sum(l => l.lineTotal);
    }
}
