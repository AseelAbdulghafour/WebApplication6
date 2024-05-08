namespace WebApplication6.Model
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal Price { get; set; }
        public string Source { get; set;}
        public Style Style { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public DesignPost Post { get; set; }
        public ItemType ItemType { get; set; }
    }
    public class ItemResponse
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal Price { get; set; }
        public string Source { get; set; }
        public string Style { get; set; }
        public string Store { get; set; }
        public string ItemType { get; set; }
    }
}
