using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_kolos2.Entities;

[Table("Visit")]
public class Visit
{
    [Key]
    public int VisitId { get; set; }
    public int ClientId { get; set; }
    public int MechanicId { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [ForeignKey(nameof(ClientId))] 
    public Client Client { get; set; }
    
    [ForeignKey(nameof(MechanicId))] 
    public Mechanic Mechanic { get; set; }
    
    public ICollection<VisitService> VisitServices { get; set; } = [];
}