using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_kolos2.Entities;

[Table("Mechanic")]
public class Mechanic
{
    [Key]
    public int MechanicId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(14)]
    public string LicenseNumber { get; set; } = string.Empty;
    
    public ICollection<Visit> Visits { get; set; } = [];
}