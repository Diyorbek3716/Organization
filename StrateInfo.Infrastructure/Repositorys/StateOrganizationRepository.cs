using Microsoft.EntityFrameworkCore;
using StateInfo.Domain.DTOs;
using StateInfo.Domain.Models;
using StrateInfo.Infrastructure.DatabaseContext;

namespace StrateInfo.Infrastructure.Repositorys;

public class StateOrganizationRepository : IStateOrganizationRepository
{
	private readonly ApplicationDbContext _context;
	public StateOrganizationRepository(ApplicationDbContext applicationDbContext)
	{
		_context = applicationDbContext;
	}
	public async Task<List<StateOrganizationModel>> GetAllOrganizationAsync()
	{
		var result= await _context.Organizations.ToListAsync();
		return result;
	}

	public async Task<Address> GetByIdAddressAsync(Guid id)
	{
		var result = _context.Addresses.FirstOrDefault(x => x.Id == id);
		return result;
	}

	public async Task<StateOrganizationModel> GetByIdOrganizationAsync(Guid id)
	{
		var result = _context.Organizations.FirstOrDefault(x => x.Id == id);
		return result;
	}
}
