using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCWebApplication.Models.Studies
{
    public class Study
    {
        public int Id { get; set; }
        [Required]
        public DateTime Beginning { get; set; }
        [Required]
        [DisplayName("Done?")]
        public bool IsFinished { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Origin { get; set; }
    }
}
