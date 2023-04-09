using StructureMap;

namespace diamir.challenge.Backend
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<ProductListVisualizer>().Use<ProductListVisualizer>();
            For<IProductRepository>().Use<DefaultExampleProductRepository>();
        }
    }
}
