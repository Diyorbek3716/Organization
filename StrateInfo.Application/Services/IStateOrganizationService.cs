using StateInfo.Domain.DTOs;
using StateInfo.Domain.Models;

namespace StrateInfo.Application.Services;

public interface IStateOrganizationService
{
	Task<List<StateOrganizationAllDTO>> GetAllOrganizationAsync();
	Task<StateOrganizationModel> GetByIdOrganization(Guid id);
}
