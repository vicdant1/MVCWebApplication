using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCWebApplication.Models.Entertainment
{
    public class Entertainment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Year is required")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public int Type { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [DisplayName("When?")]
        [Required(ErrorMessage = "'When?' is required")]
        public DateTime? SawAt { get; set; }
    }
}
