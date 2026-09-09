using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Models;
using WeddingApp.Services;

namespace WeddingApp.Pages
{
    /// <summary>
    /// Page model for the event page. It reads the event details from the shared
    /// service and exposes the number of guests who have answered so far.
    /// </summary>
    public class EventModel : PageModel
    {
        private readonly IEventService eventService;
        private readonly IGuestManager guestManager;

        public Event EventInfo { get; private set; }

        public int NumOfResponses => guestManager.NumOfGuests;

        public EventModel(IEventService eventService, IGuestManager guestManager)
        {
            this.eventService = eventService;
            this.guestManager = guestManager;
        }

        public void OnGet()
        {
            EventInfo = eventService.GetEvent();
        }
    }
}