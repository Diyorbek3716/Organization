using StateInfo.Domain.DTOs;
using StateInfo.Domain.Models;

namespace StrateInfo.Infrastructure.Repositorys;

public interface IStateOrganizationRepository
{
	Task<List<StateOrganizationModel>> GetAllOrganizationAsync();
	Task<StateOrganizationModel> GetByIdOrganizationAsync(Guid id);
	Task<Address> GetByIdAddressAsync(Guid id);
}
