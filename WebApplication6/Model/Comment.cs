namespace WebApplication6.Model
{
    public class Comment
    {
        public DesignPost Design { get; set; }
        public int CommentId { get; set; }
       // public UserAccount User { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
