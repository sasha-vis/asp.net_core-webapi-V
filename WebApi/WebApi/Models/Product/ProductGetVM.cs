namespace WebApi.Models.Product
{
    public class ProductGetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
