using ContactForm.Models;
using Microsoft.EntityFrameworkCore;

public class ContactFormDbContext : DbContext
{
    public ContactFormDbContext(DbContextOptions<ContactFormDbContext> options) : base(options) {}
    public DbSet<DetailsViewModel> Details { get; set; }
}
