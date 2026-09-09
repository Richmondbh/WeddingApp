using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Models;
using WeddingApp.Services;

namespace WeddingApp.Pages
{
    /// <summary>
    /// Page model for the RSVP form. It shows an empty form on GET and validates
    /// and stores the answer on POST.
    /// </summary>
    public class RsvpModel : PageModel
    {
        private readonly IGuestManager guestManager;

      
        [BindProperty]
        public Guest Guest { get; set; }

        public RsvpModel(IGuestManager guestManager)
        {
            this.guestManager = guestManager;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Returning Page() redisplays the form with the values the guest
            // typed and the validation messages next to the offending fields.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            guestManager.Add(Guest);

            return RedirectToPage("Confirmation",
                new { name = Guest.Name, attending = Guest.WillAttend });
        }
    }
}