namespace e_shop_backend.Core.Configuration
{
    public interface IUnitOfWork
    {
        ProductRepository Products { get; }

        void Complete();
        void Dispose();
    }
}