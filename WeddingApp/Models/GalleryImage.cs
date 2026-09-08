namespace WeddingApp.Models
{
    /// <summary>
    /// One picture shown on the gallery page. FileName  here refers to a file stored in
    /// wwwroot/images, and AltText is the text screen readers announce instead.
    /// </summary>
    public class GalleryImage
    {

        public string FileName { get; set; }

        public string Caption { get; set; }

        public string AltText { get; set; }
    }
}
