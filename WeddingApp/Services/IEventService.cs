using WeddingApp.Models;

namespace WeddingApp.Services
{
    public interface IEventService
    {

        Event GetEvent();

        IReadOnlyList<GalleryImage> GetGalleryImages();

        IReadOnlyList<Notice> GetNotices();
    }
}
