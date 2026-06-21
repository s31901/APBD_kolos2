using APBD_kolos2.DTOs;
using APBD_kolos2.Exceptions;
using APBD_kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_kolos2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitController : ControllerBase
{
    private readonly IDbService _dbService;

    public VisitController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetVisit(int id)
    {
        try
        {
            var result = await _dbService.GetVisit(id);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddVisit(AddVisitDto visit)
    {
        try
        {
            await _dbService.AddVisit(visit);
            return Created();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}