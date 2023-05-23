namespace Domain
{
    // ENTITIES = WE'LL USE AND STORE THIS IN DATABASE; IN MVC, THIS IS THE MODELS
    public class Activity
    {
        // set properties
        public Guid Id { get; set; } // GUID stands for Global Unique Identifier
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}