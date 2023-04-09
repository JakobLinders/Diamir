using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diamir.challenge.Backend.Models
{
    public class ProductRegistry : Registry
    {
        public ProductRegistry()
        {
            For<ProductListVisualizer>().Use<ProductListVisualizer>();
            For<IProductRepository>().Use<ProductRepository>();
        }
    }
}
