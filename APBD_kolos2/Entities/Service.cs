using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_kolos2.Entities;

[Table("Service")]
public class Service
{
    [Key]
    public int ServiceId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;  
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal BaseFee { get; set; }  
    
    public ICollection<VisitService> VisitServices { get; set; } = [];
}