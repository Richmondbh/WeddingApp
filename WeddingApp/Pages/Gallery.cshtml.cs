using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Models;
using WeddingApp.Services;

namespace WeddingApp.Pages
{
    /// <summary>
    /// Page model for the photo gallery. The pictures themselves are static files
    /// in wwwroot/images; and the service only supplies the file names and captions.
    /// </summary>
    public class GalleryModel : PageModel
    {
        private readonly IEventService eventService;

        public IReadOnlyList<GalleryImage> Images { get; private set; }

        public GalleryModel(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public void OnGet()
        {
            Images = eventService.GetGalleryImages();
        }
    }
}