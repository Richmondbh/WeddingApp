using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Models;
using WeddingApp.Services;

namespace WeddingApp.Pages.Guests
{
    /// <summary>
    /// Page model for the guest list. It reads every stored response and handles
    /// deletion of a single guest.
    /// </summary>
    public class GuestListModel : PageModel
    {
        private readonly IGuestManager guestManager;

        // TempData survives exactly one redirect, which is how the result of a
        // delete can be shown on the freshly loaded page.
        [TempData]
        public string StatusMessage { get; set; }

        public IReadOnlyList<Guest> Guests { get; private set; }

        public int NumOfAttending => Guests.Count(guest => guest.WillAttend == true);

        public GuestListModel(IGuestManager guestManager)
        {
            this.guestManager = guestManager;
        }

        public void OnGet()
        {
            Guests = guestManager.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            bool wasDeleted = guestManager.Delete(id);

            StatusMessage = wasDeleted
                ? "The guest was removed from the list."
                : "The guest could not be found.";

            // Redirecting instead of returning Page() means a refresh does not
            // repeat the delete.
            return RedirectToPage();
        }
    }
}