using System.ComponentModel.DataAnnotations;

namespace WeddingApp.Models
{
    /// <summary>
    /// Represents one guest's response to the wedding invitation. The validation
    /// rules are enforced by ASP.NET Core when the RSVP form is submitted.
    /// </summary>
    public class Guest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kindly enter your name.")]
        [StringLength(60, MinimumLength = 2,
            ErrorMessage = "The name must be between 2 and 70 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        // Nullable so that [Required] so that it can can detect an unanswered question. Beacuse a plain
        // bool would default to false and always pass validation.
        [Required(ErrorMessage = "Please let us know whether you can attend.")]
        [Display(Name = "Will you attend?")]
        public bool? WillAttend { get; set; }

        [MaxLength(200, ErrorMessage = "The message may not exceed 200 characters.")]
        [Display(Name = "Message to the hosts")]
        public string Message { get; set; }
    }
}
