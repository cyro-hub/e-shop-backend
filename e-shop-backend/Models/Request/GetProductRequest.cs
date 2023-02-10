namespace e_shop_backend.Models.Request
{
    public class GetProductRequest
    {
        public int currentPage { get; set; }
     /*   public int currentPage { get; set; }*/
        public string searchQuery { get; set; } = string.Empty;
    }
}
