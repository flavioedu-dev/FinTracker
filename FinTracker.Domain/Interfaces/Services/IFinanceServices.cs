using FinTracker.Domain.DTO;
using FinTracker.Domain.DTO.Response;

namespace FinTracker.Domain.Interfaces.Services;

public interface IFinanceServices
{
    FinanceResponseDTO GetFinancesByUser(string username);

    FinanceResponseDTO RegisterFinance(FinanceDTO financeDto);
}
