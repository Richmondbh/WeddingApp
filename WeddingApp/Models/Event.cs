namespace WeddingApp.Models
{

    /// <summary>
    /// This describes the wedding event that guests are invited to. Date and Time are
    /// kept as text because the values are only displayed, never calculated with.
    /// </summary>
    public class Event
    {
        public string Title { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string RsvpDeadline { get; set; }
    }
}
