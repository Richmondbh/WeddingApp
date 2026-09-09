using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Models;
using WeddingApp.Services;

namespace WeddingApp.Pages
{
    /// <summary>
    /// Page model for the event page. It reads the event details and the notices
    /// from the shared service and exposes the number of responses received.
    /// </summary>
    public class EventModel : PageModel
    {
        private readonly IEventService eventService;
        private readonly IGuestManager guestManager;

        public Event EventInfo { get; private set; }

        public IReadOnlyList<Notice> Notices { get; private set; }

        public int NumOfResponses => guestManager.NumOfGuests;

        public EventModel(IEventService eventService, IGuestManager guestManager)
        {
            this.eventService = eventService;
            this.guestManager = guestManager;
        }

        public void OnGet()
        {
            EventInfo = eventService.GetEvent();
            Notices = eventService.GetNotices();
        }
    }
}