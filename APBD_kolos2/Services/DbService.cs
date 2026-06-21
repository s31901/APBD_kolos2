using APBD_kolos2.Data;
using APBD_kolos2.DTOs;
using APBD_kolos2.Entities;
using APBD_kolos2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APBD_kolos2.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbContext;
    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<VisitDto> GetVisit(int visitId)
    {
        var res = _dbContext.Visits
            .Where(v => v.VisitId == visitId)
            .Select(v => new VisitDto
            {
                Date = v.Date,
                Client = new ClientDto
                {
                    FirstName = v.Client.FirstName,
                    LastName = v.Client.LastName,
                    DateOfBirth = v.Client.DateOfBirth
                },
                Mechanic = new MechanicDto
                {
                    MechanicId = v.Mechanic.MechanicId,
                    LicenseNumber = v.Mechanic.LicenseNumber
                },
                VisitServices = v.VisitServices.Select(vs => new VisitServiceDto
                {
                    Name = vs.Service.Name,
                    ServiceFee = vs.ServiceFee
                })
            }).FirstOrDefault();
        
        if (res == null)
        {
            throw new NotFoundException();
        }
        
        return res;

    }

    public async Task AddVisit(AddVisitDto dto)
    {
        var services = dto.Services.Select(s => s.ServiceName).ToList();
        
        var existingServices = await _dbContext.Services
            .Select(s => s.Name)
            .ToListAsync();
        var missingService = services.Except(existingServices).ToList();
        
        if (missingService.Any()) throw new NotFoundException("Services not found");
        
        if (dto.ClientId == null) throw new NotFoundException("Client not found");


        var mechanic = await _dbContext.Mechanics
            .FirstOrDefaultAsync(m => m.LicenseNumber == dto.MechanicLicenseNumber);
        if (mechanic == null) throw new NotFoundException("Mechanic not found");
        
        var client = await _dbContext.Clients
            .FirstOrDefaultAsync(c => c.ClientId == dto.ClientId);
        if (client == null) throw new NotFoundException("Client not found");
        
        var visit = new Visit
        {
            ClientId = dto.ClientId,
            MechanicId = _dbContext.Mechanics.Where(m => m.LicenseNumber == dto.MechanicLicenseNumber)
                .Select(m => m.MechanicId).FirstOrDefault(),
            Date = DateTime.Now
        };

        await _dbContext.AddAsync(visit);
        await _dbContext.SaveChangesAsync();
        
        foreach (var service in dto.Services)
        {
            var visitService = new VisitService
            {
                VisitId = visit.VisitId,
                ServiceId = _dbContext.Services.Where(s => s.Name == service.ServiceName)
                    .Select(s => s.ServiceId).FirstOrDefault(),
                ServiceFee = service.ServiceFee
            };
            await _dbContext.AddAsync(visitService);
            await _dbContext.SaveChangesAsync();
        }
    }
    
    


}