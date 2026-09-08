using WeddingApp.Models;

namespace WeddingApp.Services
{

    /// <summary>
    /// Holds the content of the site in memory. Keeping it here instead of in the
    /// page models means that every page reads the same values from one place.
    /// </summary>
    public class EventService: IEventService
    {

        private readonly Event weddingEvent;
        private readonly List<GalleryImage> galleryImages;
        private readonly List<Notice> notices;

        public EventService()
        {
            weddingEvent = new Event
            {
                Title = "My 7 years Anniversay!",
                Date = "Novermber 26, 2026",
                Time = "17:00",
                Location = "Arena, Östersund, Sweden",
                Description = "An evening of dinner, music and dancing with the "
                    + "people who matter most to us.",
                RsvpDeadline = "October 1, 2026"
            };

            
            galleryImages = new List<GalleryImage>
            {
                new GalleryImage
                {
                    FileName = "gallery-1.jpg",
                    Caption = "The proposal",
                    AltText = "The couple on the evening of the proposal"
                },
                new GalleryImage
                {
                    FileName = "gallery-2.jpg",
                    Caption = "The venue",
                    AltText = "The garden outside Springfield Wedding Hall"
                },
                new GalleryImage
                {
                    FileName = "gallery-3.jpg",
                    Caption = "The engagement party",
                    AltText = "Friends and family at the engagement party"
                }
            };

            notices = new List<Notice>
            {
                new Notice
                {
                    Heading = "Venue confirmed",
                    Text = "The ceremony and the dinner will both be held at "
                        + "Ötersund Area.",
                    PublishedOn = "April 7, 2027"
                },
                new Notice
                {
                    Heading = "Schedule updated",
                    Text = "The ceremony starts at 17:00 and dinner is served "
                        + "at 19:00.",
                    PublishedOn = "April 12, 2026"
                }
            };
        }

        public Event GetEvent()
        {
            return weddingEvent;
        }

        public IReadOnlyList<GalleryImage> GetGalleryImages()
        {
            return galleryImages;
        }

        public IReadOnlyList<Notice> GetNotices()
        {
            return notices;
        }
    }
}
