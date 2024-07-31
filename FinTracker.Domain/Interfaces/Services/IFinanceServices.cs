using FinTracker.Domain.DTO;
using FinTracker.Domain.DTO.Response.Finance;

namespace FinTracker.Domain.Interfaces.Services;

public interface IFinanceServices
{
    GetFinanceByUserResponseDTO GetFinancesByUser(int userId);

    RegisterFinanceResponseDTO RegisterFinance(FinanceDTO financeDto);
}
