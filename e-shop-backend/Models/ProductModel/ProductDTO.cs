namespace e_shop_backend.Models.ProductModel
{
    public class ProductDTO
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string category { get; set; }
        public DateTime productionDate { get; set; }
        public DateTime expiryDate { get; set; }
        public string storageLocation { get; set; }
        public bool isActive { get; set; }
    }
}
