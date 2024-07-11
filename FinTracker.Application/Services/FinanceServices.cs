using FinTracker.Application.Resources;
using FinTracker.Domain.DTO;
using FinTracker.Domain.DTO.Response;
using FinTracker.Domain.Entities;
using FinTracker.Domain.Exceptions;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using Mapster;
using System.Net;

namespace FinTracker.Application.Services;

public class FinanceServices : IFinanceServices
{
    private readonly IUserRepository _userRepository;
    private readonly IFinanceRepository _financeRepository;

    public FinanceServices(IUserRepository userRepository, IFinanceRepository financeRepository)
    {
        _userRepository = userRepository;
        _financeRepository = financeRepository;
    }

    public FinanceResponseDTO GetFinancesByUser(string username)
    {
        throw new NotImplementedException();
    }

    public FinanceResponseDTO RegisterFinance(FinanceDTO financeDTO)
    {
        try
        {
            User? userRegistered = _userRepository.Get(x => x.Id == financeDTO.UserId)
                ?? throw new UserException(HttpStatusCode.NotFound, ApplicationMessages.GetUser_Fail);

            Finance finance = financeDTO.Adapt<Finance>();

            Finance? financeRegistered = _financeRepository.Add(finance);

            FinanceResponseDTO financeResponseDTO = financeRegistered.Adapt<FinanceResponseDTO>();

            return financeResponseDTO;
        }
        catch (Exception ex)
        {
            throw new FinanceException(HttpStatusCode.BadRequest, ApplicationMessages.RegisterFinance_Fail, ex);
        }
    }
}
