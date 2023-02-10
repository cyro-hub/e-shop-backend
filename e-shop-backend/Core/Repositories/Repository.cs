using e_shop_backend.Models.ProductModel;

namespace e_shop_backend.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected ILogger _logger;

        public Repository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<ActionResult<Response<T>>> GetAll()
        {
            try
            {
                var products = await _context.Set<T>().ToListAsync();

                return new Response<T>()
                {
                    Data = products,
                    IsSuccess = true,
                    message = "Successfully Operation",
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAll no filters method error", typeof(Repository<T>));

                return new Response<T>()
                {
                    Data = new List<T>(),
                    IsSuccess = false,
                    message = "Failed Operation",
                };
            }
        }
        public async Task<ActionResult<Response<T>>> GetByID(Guid id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);

                if (entity == null)
                {
                    return new Response<T>()
                    {
                        Data = new List<T>() { entity },
                        IsSuccess = true,
                        message = "Failed Operation"
                    };
                }

                return new Response<T>()
                {
                    Data = new List<T>() { entity },
                    IsSuccess = true,
                    message = "Successfully Operation"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetByID method error", typeof(Repository<T>));

                return new Response<T>()
                {
                    Data = new List<T>(),
                    IsSuccess = true,
                    message = "Failed Operation"
                };
            }
        }
        public bool Remove(Guid id)
        {
            try
            {
                if (id == null) return false;

                var entity = _context.Set<T>().Find(id);

                if (entity == null) return false;

                _context.Set<T>().Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} remove entity method error", typeof(Repository<T>));
                return false;
            }
        }
        public virtual async Task<ActionResult<bool>> AddEntity(T req)
        {
            try
            {
                if (req == null) return false;

                await _context.Set<T>().AddAsync(req);

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add entity method error", typeof(Repository<T>));
                return false;
            }
        }
    }
}
