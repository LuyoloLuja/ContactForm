using System.ComponentModel.DataAnnotations;

namespace ContactForm.Models;

public class DetailsViewModel
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    [RegularExpression(@"^[a-zA-Z' -]{2,50}$", ErrorMessage = "Please enter a valid first name.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
    [RegularExpression(@"^[a-zA-Z' -]{2,50}$", ErrorMessage = "Please enter a valid last name.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "To submit this form, please consent to being contacted")]
    [Display(Name = "I consent to being contacted by the team")]
    public bool IsChecked { get; set; }

    [Required(ErrorMessage = "Message is required.")]
    [StringLength(500, ErrorMessage = "Message cannot be longer than 500 characters.")]
    public string Message { get; set; }

    [Required(ErrorMessage = "Please select a query type")]
    [Display(Name = "Query Type *")]
    public QueryType? SelectQueryType { get; set; }

}

public enum QueryType
{
    [Display(Name = "General Enquiery")]
    GeneralEnquiery,

    [Display(Name = "Support Request")]
    SupportRequest
}