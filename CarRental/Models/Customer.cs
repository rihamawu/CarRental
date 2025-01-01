using System.ComponentModel.DataAnnotations;

namespace CarRental.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
