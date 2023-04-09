using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diamir.challenge.Backend.Models
{
    public class ProductDto : IProductDto
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("ProductName")]
        public string Name { get; set; }
        [JsonProperty("Price")]
        public decimal Price { get; set; }
    }
}
