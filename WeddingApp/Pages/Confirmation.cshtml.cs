using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeddingApp.Pages
{
    /// <summary>
    /// Page model for the confirmation page. The values arrive as route data from
    /// the redirect in RsvpModel.OnPost, so that no guest is looked up here.
    /// </summary>
    public class ConfirmationModel : PageModel
    {
        public string GuestName { get; private set; }

        public bool IsAttending { get; private set; }

        public void OnGet(string name, bool attending)
        {
            GuestName = name;
            IsAttending = attending;
        }
    }
}