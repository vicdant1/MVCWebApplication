namespace MVCWebApplication.Models.Entertainment
{
    public class Entertainment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Type { get; set; }
        public string Country { get; set; }
        public DateTime SawAt { get; set; }
    }
}
