using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        [NotMapped]
        public object Data { get; set; }
    }
}
