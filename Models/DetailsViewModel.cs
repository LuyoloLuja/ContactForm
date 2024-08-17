using System.ComponentModel.DataAnnotations;

namespace ContactForm.Models;

public class DetailsViewModel
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "First Name *")]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Last Name *")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Email Address *")]
    [StringLength(50)]
    public string Email { get; set; }

    [Required(ErrorMessage = "To submit this form, please consent to being contacted")]
    [Display(Name = "I consent to being contacted by the team")]
    public bool IsChecked { get; set; }

    [Required(ErrorMessage = "This field required")]
    [Display(Name = "Message *")]
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