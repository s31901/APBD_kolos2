using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_kolos2.Entities;

[Table("Visit_Service")]
[PrimaryKey(nameof(VisitId), nameof(ServiceId))]
public class VisitService
{
    public int VisitId { get; set; }
    public int ServiceId { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal ServiceFee { get; set; }
    
    [ForeignKey(nameof(VisitId))]
    public Visit Visit {get; set; }
    
    [ForeignKey(nameof(ServiceId))]
    public Service Service {get; set; }
}