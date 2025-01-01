using System.ComponentModel.DataAnnotations;

namespace CarRental.Models;

public class Car
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Brand { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public bool IsAvailable { get; set; } = true;

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
