using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCurroptionLayer.SimpleImplementation.ACL.Entities
{
    public class Item
    {
        public Guid ITEM_ID { get; set; }
        public string ITEM_DESC { get; set; }
        public int ITEM_QUANTITY { get; set; }
        public int ITEM_PRICE_SELLING { get; set; }
    }

    public class item_api
    {
        public Guid item_id { get; set; }
        public string item_name { get; set; }
        public int item_quantity { get; set; }
        public int item_selling_price { get; set; }
    }
}
