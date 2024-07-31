using Mapster;
using FinTracker.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.API.Models.Finance;
using FinTracker.Domain.DTO.Response.Finance;

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

    [HttpGet]
    public IActionResult GetFinancesByUser(GetFinancesByUserModel getFinancesByUserModel)
    {
        GetFinanceByUserResponseDTO getFinanceByUserResponseDTO = _financeServices.GetFinancesByUser(getFinancesByUserModel.UserId);

        return StatusCode(StatusCodes.Status200OK, getFinanceByUserResponseDTO);
    }

    [HttpPost]
    public IActionResult RegisterFinance(CreateFinanceModel financeModel)
    {
        FinanceDTO financeDTO = financeModel.Adapt<FinanceDTO>();

        RegisterFinanceResponseDTO financeResponseDTO = _financeServices.RegisterFinance(financeDTO);

        return StatusCode(StatusCodes.Status201Created, financeResponseDTO);
    }
}
