namespace WebApi.Models
{
    public class OrderGetVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public List<int> ProductsId { get; set; }
        public int TotalPrice { get; set; }
        public string Date { get; set; }
    }
}
