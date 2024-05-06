using System.ComponentModel.DataAnnotations;
using WebApplication6.Model;

namespace DesignDistrict.Frontend.Model
{
    public class Post
    {
        public int Id { get; set; }

       
        public string PostImage { get; set; }

       
        public string PostDescription { get; set; }

       
        public List<Item> Item { get; set; }

      
        public List<Store> Store { get; set; }

       
        public string Catagory { get; set; }

     
        public decimal TotalPrice { get; internal set; }
    }
}
