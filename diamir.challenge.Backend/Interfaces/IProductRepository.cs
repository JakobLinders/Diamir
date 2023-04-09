using System.Collections.Generic;

namespace diamir.challenge.Backend
{
    public interface IProductRepository
    {
        IEnumerable<IProductDto> GetProducts();

        IEnumerable<IProductDto> GetProducts(int start, int pageSize);
    }
}
