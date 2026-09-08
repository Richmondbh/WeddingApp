namespace WeddingApp.Models
{  /// <summary>
   /// A short update for the guests, for example a confirmed venue or a changed
   /// schedule. 
   /// </summary>
    public class Notice
    {

        public string Heading { get; set; }

        public string Text { get; set; }

        public string PublishedOn { get; set; }
    }
}

