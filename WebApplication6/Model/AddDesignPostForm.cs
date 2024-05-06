using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Model
{
    public class AddDesignPostForm
    {
        public int Id { get; set; }

        [Required]
        public string PostImage { get; set; }

        [Required]
        public string PostDescription { get; set; }

        [Required]
        public List<Item> Item { get; set; }

        [Required]
        public List<Store> Store { get; set; }

        [Required]
        public string Catagory { get; set; }

        [Required]
        public decimal TotalPrice { get; internal set; }
    }
}
