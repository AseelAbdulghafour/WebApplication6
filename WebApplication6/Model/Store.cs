namespace WebApplication6.Model
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }
        public string StoreWebsite { get; set; }
        public List<Item> Items { get; set;}
    }
}
