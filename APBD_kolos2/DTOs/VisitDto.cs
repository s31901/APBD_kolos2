namespace APBD_kolos2.DTOs;

public class VisitDto
{
    public DateTime Date { get; set; }
    public ClientDto Client { get; set; }
    public MechanicDto Mechanic { get; set; }
    public IEnumerable<VisitServiceDto> VisitServices { get; set; } = [];   
}

public class ClientDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}

public class MechanicDto
{
    public int MechanicId { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
}

public class VisitServiceDto
{
    public string Name { get; set; } = string.Empty;
    public decimal ServiceFee { get; set; }
}