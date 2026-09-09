using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Models;
using WeddingApp.Services;

namespace WeddingApp.Pages.Guests
{
    /// <summary>
    /// Page model for editing one stored guest response. The same validation
    /// rules as on the RSVP form apply, because they live on the Guest class.
    /// </summary>
    public class EditGuestModel : PageModel
    {
        private readonly IGuestManager guestManager;

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public Guest Guest { get; set; }

        public EditGuestModel(IGuestManager guestManager)
        {
            this.guestManager = guestManager;
        }

        public IActionResult OnGet(int id)
        {
            Guest = guestManager.GetById(id);

            // Guards against a hand-typed or stale id in the address bar.
            if (Guest == null)
            {
                StatusMessage = "The guest could not be found.";
                return RedirectToPage("./GuestList");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!guestManager.Update(Guest))
            {
                StatusMessage = "The guest could not be found.";
                return RedirectToPage("./GuestList");
            }

            StatusMessage = "The changes were saved.";
            return RedirectToPage("./GuestList");
        }
    }
}