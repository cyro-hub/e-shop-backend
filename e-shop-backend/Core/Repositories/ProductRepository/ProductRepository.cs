using e_shop_backend.Models.ProductModel;

namespace e_shop_backend.Core.Repositories.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected ApplicationDbContext _context;
        protected ILogger _logger;

        public ProductRepository(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<Response<Product>>> GetAllWithQuery(GetProductRequest req)
        {
            try
            {
                var pageSize = 10f;

                if (req == null) return new Response<Product>();

                if (req.currentPage <= 0) req.currentPage = 1;

                var numberOfPages = Math.Ceiling(_context.Set<Product>()
                                    .Where(product =>
                                    (
                                        product.name.Contains(req.searchQuery) ||
                                        product.category.Contains(req.searchQuery))
                                    ).Count() / pageSize);

                var products = await _context.Set<Product>()
                                        .Where(product =>
                                        (
                                            product.name.Contains(req.searchQuery) ||
                                            product.category.Contains(req.searchQuery))
                                        ).Skip((req.currentPage - 1) * (int)pageSize)
                                        .Take((int)pageSize)
                                        .ToListAsync();

                return new Response<Product>()
                {
                    Data = products.ToList(),
                    IsSuccess = true,
                    message = "Successfully Operation",
                    numberOfPages = (int)numberOfPages,
                    pageNumber = req.currentPage
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAllWithQuery no filters method error", typeof(Repository<Product>));
                return new Response<Product>()
                {
                    Data = new List<Product>(),
                    IsSuccess = false,
                    message = "Failed Operation",
                    pageNumber = req.currentPage
                };
            }
        }

        public async Task<ActionResult<bool>> UpdateProduct(Product product)
        {
            try
            {
                var p = await _context.Set<Product>().FindAsync(product.id);

                p.name = product.name;
                p.isActive = product.isActive;
                p.price = product.price;
                p.quantity = product.quantity;
                p.expiryDate = product.expiryDate;
                p.category = product.category;
                p.storageLocation = product.storageLocation;
                p.productionDate = product.productionDate;
                p.createdAt = product.createdAt;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} updating method error", typeof(Repository<Product>));

                return false;
            }


        }

    }
}
