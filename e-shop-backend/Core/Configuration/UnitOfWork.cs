namespace e_shop_backend.Core.Configuration
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            Products = (new ProductRepository(context, loggerFactory.CreateLogger("logs")));
        }
        public ProductRepository Products { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
