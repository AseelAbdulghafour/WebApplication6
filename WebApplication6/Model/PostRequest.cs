namespace WebApplication6.Model
{
    public class PostRequest
    {
        public string PostDescription { get; set; }
        public string Catagory { get; set; }
        public IFormFile PostImage { get; set; }
        public decimal TotalPrice { get; internal set; }

    }
}
