using StateInfo.Domain.DTOs;
using StateInfo.Domain.Models;
using StrateInfo.Infrastructure.Repositorys;

namespace StrateInfo.Application.Services;

public class StateOrganizationService : IStateOrganizationService
{
	private readonly IStateOrganizationRepository _repository;
	public StateOrganizationService(IStateOrganizationRepository repository)
	{
		_repository = repository;
	}
	public async Task<List<StateOrganizationAllDTO>> GetAllOrganizationAsync()
	{
		try
		{
			var getAllOrganization = await _repository.GetAllOrganizationAsync();
			var result = new List<StateOrganizationAllDTO>();

			foreach (var organization in getAllOrganization)
			{
				var getOrganization = new StateOrganizationAllDTO();  // Yangi obyektni har safar yaratish
				getOrganization.Id = organization.Id;
				getOrganization.Name = organization.Name;
				getOrganization.PhotoUrl = organization.PhotoUrl;

				// Manzilni olish
				var address = await _repository.GetByIdAddressAsync(organization.AddressId);
				getOrganization.City = address.City;

				result.Add(getOrganization);
			}

			return result;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<StateOrganizationModel> GetByIdOrganization(Guid id)
	{
		try
		{
			var result = await _repository.GetByIdOrganizationAsync(id);
			return result;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
