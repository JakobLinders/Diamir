using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace diamir.challenge.Backend.Models
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductDto> rootObjects;

        private static string _key = "foo";
        private static readonly MemoryCache _cache = MemoryCache.Default;

        public static void StoreItemsInCache()
        {
            IEnumerable<IProductDto> itemsToAdd = ReadJson();

            var cacheItemPolicy = new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTime.Now.AddDays(1)
            };

            _cache.Add(_key, itemsToAdd, cacheItemPolicy);
        }

        public static IEnumerable<IProductDto> GetItemsFromCache()
        {
            if (!_cache.Contains(_key))
                StoreItemsInCache();

            return _cache.Get(_key) as IEnumerable<IProductDto>;
        }

        public static IEnumerable<IProductDto> ReadJson()
        {
            string path = @"C:\Users\conso\Desktop\Övrigt\Kod\Diamir\diamir.challenge\diamir.challenge\diamir.challenge.Backend\diamir.challenge.Backend\products.json";

            List<ProductDto> rootObjects;
            using (var r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                rootObjects = JsonConvert.DeserializeObject<List<ProductDto>>(json);
            }

            return rootObjects;
        }
        public IEnumerable<IProductDto> GetProducts()
        {
            return GetItemsFromCache();
        }

        public IEnumerable<IProductDto> GetProducts(int start, int pageSize)
        {
            var p = GetProducts().ToList();

            var products = p.GetRange(start, pageSize);

            return products;
        }
    }
}
