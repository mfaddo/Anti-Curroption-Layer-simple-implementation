using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCurroptionLayer.SimpleImplementation.Domain
{
    public class OrderLine
    {
        internal Guid Id { get; set; }
        internal Guid ProductId { get; set; }
        internal int Qty { get; private set; }
        internal int Price { get; private set; }
        internal int lineTotal { get; private set; }

        internal static OrderLine FromProduct(Guid ProductId, int Quantity , IProductTranslator productTranslator)
        {
            var line = new OrderLine();
            var product= line.validateQty(ProductId, Quantity, productTranslator);
            
            line.Qty= product.AvailableQty;
            line.Price= product.Price;
            line.Id = Guid.NewGuid();
            line.ProductId = ProductId;

            line.computeLineTotal();
            return line;   
        }

        internal void updateLineQty(int Qty, IProductTranslator productTranslator) {
            validateQty(ProductId, Qty,  productTranslator);
            this.Qty = Qty;
            computeLineTotal();
        }

        private void computeLineTotal() => lineTotal = Qty * Price;

        private  Product validateQty(Guid ProductId, int Quantity, IProductTranslator productTranslator)
        {
            if(Qty < 0)
                 throw new InvalidOperationException(
                     "Prodcut Quantity is invalid");
                
            var product = productTranslator.FindProduct(ProductId);
            if (product.AvailableQty >= Quantity)
            {
                return product;
            }

            throw new InvalidOperationException(
                "Prodcut Quantity is invalid");
        }

    }
}
