 namespace Entities
{
    public class Event
    {
        public Guid Id { get; set; }

        public  string? Title { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public  string? City { get; set; }

        public string? Place { get; set; }

        public DateTime Date { get; set; }
    }
}
