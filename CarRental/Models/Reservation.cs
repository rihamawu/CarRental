using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models;

public class Reservation
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CarId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public DateTime StartDate { get; set; } 

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }

    [ForeignKey("CarId")]
    public Car Car { get; set; } = new Car();

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; } = new Customer();
}
