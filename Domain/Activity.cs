namespace Domain
{
    public class Activity //<--Entity(ORM - EF Core) || Model
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}