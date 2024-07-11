using Mapster;
using FinTracker.API.Models;
using FinTracker.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using FinTracker.Domain.DTO.Response;
using FinTracker.Domain.Interfaces.Services;

namespace FinTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinanceController : Controller
{
    private readonly IFinanceServices _financeServices;
    
    public FinanceController(IFinanceServices financeServices)
    {
        _financeServices = financeServices;
    }

    [HttpPost]
    public IActionResult RegisterFinance(FinanceModel financeModel)
    {
        FinanceDTO financeDTO = financeModel.Adapt<FinanceDTO>();

        FinanceResponseDTO financeResponseDTO = _financeServices.RegisterFinance(financeDTO);

        return StatusCode(StatusCodes.Status201Created, financeResponseDTO);
    }
}
