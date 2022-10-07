using AntiCurroptionLayer.SimpleImplementation.ACL.Adaptors;
using AntiCurroptionLayer.SimpleImplementation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCurroptionLayer.SimpleImplementation.ACL.Traslators
{
    public class ProductAPITranslator : IProductTranslator
    {
        
        public  Product FindProduct(Guid id)
        {
            var ItemsApiAdator = new ItemsApiAdaptor();
            var apiItem =  ItemsApiAdator.FindProduct(id).Result;

            return new Product(apiItem.item_id, apiItem.item_quantity, 
                apiItem.item_selling_price, apiItem.item_name);
        }
    }
}
