namespace e_shop_backend.Models.Response
{
    public class Response<T>
    {
        public List<T> Data { get; set; }
        public bool IsSuccess { get; set; }
        public string message { get; set; }
        public int pageNumber { get; set; }
        public int numberOfPages { get; set; }
    }
}
