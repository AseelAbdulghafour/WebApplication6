namespace WebApplication6.Model.Responses
{
    public class DesignDistrictResponse

        {
            public string PostImage { get; set; }
            public string Catagory { get; set; }
            public string Username { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
            public int Id { get; set; }
        public List<ItemResponse> Items { get; set; }
        public List<CommentResponse> Comments { get; set; }
        }
    }
public class CommentResponse
{
    public string Comment { get; set; }
}

