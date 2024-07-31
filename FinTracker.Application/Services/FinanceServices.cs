using FinTracker.Application.Resources;
using FinTracker.Domain.DTO;
using FinTracker.Domain.DTO.Response.Finance;
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

    public GetFinanceByUserResponseDTO GetFinancesByUser(long userId)
    {
        throw new NotImplementedException();
    }

    public RegisterFinanceResponseDTO RegisterFinance(FinanceDTO financeDTO)
    {
        try
        {
            User? userRegistered = _userRepository.Get(x => x.Id == financeDTO.UserId)
                ?? throw new UserException(HttpStatusCode.NotFound, ApplicationMessages.GetUser_Fail);

            Finance finance = financeDTO.Adapt<Finance>();

            Finance? financeRegistered = _financeRepository.Add(finance);

            RegisterFinanceResponseDTO financeResponseDTO = financeRegistered.Adapt<RegisterFinanceResponseDTO>();

            return financeResponseDTO;
        }
        catch (Exception ex)
        {
            throw new FinanceException(HttpStatusCode.BadRequest, ApplicationMessages.RegisterFinance_Fail, ex);
        }
    }
}
