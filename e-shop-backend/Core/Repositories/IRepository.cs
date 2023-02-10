namespace e_shop_backend.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<ActionResult<bool>> AddEntity(T req);
        Task<ActionResult<Response<T>>> GetAll();
        Task<ActionResult<Response<T>>> GetByID(Guid id);
        bool Remove(Guid id);
    }
}