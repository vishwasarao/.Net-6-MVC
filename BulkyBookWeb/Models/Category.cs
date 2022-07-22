using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Name")]
        [Range(1,200,ErrorMessage ="Display Order must be between 1 an 200")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    }
}
