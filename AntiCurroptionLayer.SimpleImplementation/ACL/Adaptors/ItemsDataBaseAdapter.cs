using AntiCurroptionLayer.SimpleImplementation.ACL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCurroptionLayer.SimpleImplementation.ACL.Adaptors
{
    public class ItemsDataBaseAdapter
    {
        private readonly DataBaseAdaptor adaptor;
        public ItemsDataBaseAdapter(DataBaseAdaptor adaptor)
        {
            this.adaptor = adaptor; 
        }

        public Item GetItemById (Guid id)
        {
            return adaptor.Items.FirstOrDefault(i=>i.ITEM_ID == id);
        }
    }
}
