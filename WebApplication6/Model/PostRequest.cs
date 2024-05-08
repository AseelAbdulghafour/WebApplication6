using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Model
{
    public class PostRequest
    {
        public string PostDescription { get; set; }
        public int CatagoryId { get; set; }
        public IFormFile PostImage { get; set; }

        //public int StyleId { get; set; }
        public decimal TotalPrice { get; set; }
       // public List<NewItemRequest> ItemsId { get; set; }

    }
    public class NewItemRequest
    {
        public string URLLink { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int StyleId { get; set; }
        public string Name { get; set; }
        public int ItemTypeId { get; set; }

    }
}
