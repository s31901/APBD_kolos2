using System.ComponentModel.DataAnnotations;

namespace APBD_kolos2.DTOs;

public class AddVisitDto
{
    public int ClientId { get; set; }
    
    [Required]
    [MaxLength(14)]
    public string MechanicLicenseNumber { get; set; } = string.Empty;
    
    [Required]
    [MinLength(1)]
    public ICollection<ServiceDto> Services { get; set; } = [];
}

public class ServiceDto
{
    [Required]
    [MaxLength(100)]
    public string ServiceName { get; set; } = string.Empty;
    
    [Range(0, 1000000)]
    public decimal ServiceFee { get; set; }
}