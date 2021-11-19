using MediatorPattern.Core.Models;

namespace MediatorPattern.Core.Repositories
{
    public interface IProductModelRepo
    {
        public ProductModel Insert(ProductModel productModel);
    }
}
