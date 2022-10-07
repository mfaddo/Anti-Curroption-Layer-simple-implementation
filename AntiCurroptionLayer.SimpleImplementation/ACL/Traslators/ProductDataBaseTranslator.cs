using AntiCurroptionLayer.SimpleImplementation.ACL.Adaptors;
using AntiCurroptionLayer.SimpleImplementation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCurroptionLayer.SimpleImplementation.ACL.Traslators
{
    public class ProductDataBaseTranslator : IProductTranslator
    {
        private readonly ItemsDataBaseAdapter itemsDataBaseAdapter;
        public ProductDataBaseTranslator(ItemsDataBaseAdapter itemsDataBaseAdapter)
        {
            this.itemsDataBaseAdapter = itemsDataBaseAdapter;
        }

        public Product FindProduct(Guid id)
        {
           var item = itemsDataBaseAdapter.GetItemById(id);

            return new Product(item.ITEM_ID, item.ITEM_QUANTITY, 
                item.ITEM_PRICE_SELLING, item.ITEM_DESC);
         
        }
    }
}
