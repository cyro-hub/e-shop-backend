namespace e_shop_backend.Core.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<ActionResult<Response<Product>>> GetAllWithQuery(GetProductRequest req);
        Task<ActionResult<bool>> UpdateProduct(Product product);
    }
}