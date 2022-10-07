using AntiCurroptionLayer.SimpleImplementation.ACL.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCurroptionLayer.SimpleImplementation.ACL.Adaptors
{
    public class ItemsApiAdaptor
    {
        private const string ITMES_URL = "/items/Find";

        public async Task<item_api> FindProduct (Guid id)
        {
            var client = new RestClient("https://api.twitter.com/1.1");
         

            var request = new RestRequest($"{ITMES_URL}?{id}");

            return await client.GetAsync<item_api>(request);
        }
    }
}
