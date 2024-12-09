using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StateInfo.Domain.Models
{
	[Table("organization",Schema ="state_organizations")]
	public class StateOrganizationModel
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }
		[EmailAddress]
		[Required]
		public string Email { get; set; }
		public Guid AddressId { get; set; }
		[Required]
		public string TelephoneNumber { get; set; }
		public string? PhotoUrl { get; set; }
		public string? Description { get; set; }
	}
}
