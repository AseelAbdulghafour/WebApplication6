namespace WebApplication6.Model
{
    public class DesignPost
    {
        public int Id { get; set; }
        public UserAccount User { get; set; }
        public string PostImage { get; set; }
        public string PostDescription { get; set; }
        public List<Item> Item { get; set; }
        public List<Comment> Comments { get; set; }
        public string Catagory { get; set; }
        public int TotalPrice { get; internal set; }
    }
}
