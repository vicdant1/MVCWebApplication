using System.ComponentModel;

namespace MVCWebApplication.Models.Studies
{
    public class Study
    {
        public int Id { get; set; }
        public DateTime Beginning { get; set; }
        [DisplayName("Done?")]
        public bool IsFinished { get; set; }
        public string Content { get; set; }
        // create an enum later
        public int Origin { get; set; }
    }
}
