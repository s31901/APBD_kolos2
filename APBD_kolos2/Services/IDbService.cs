using APBD_kolos2.DTOs;

namespace APBD_kolos2.Services;

public interface IDbService
{
    
    Task<VisitDto> GetVisit(int visitId);  
    Task AddVisit(AddVisitDto dto);
}