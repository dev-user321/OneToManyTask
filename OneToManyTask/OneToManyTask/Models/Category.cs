using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace OneToManyTask.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Input Bos Ola Bilmez !")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
