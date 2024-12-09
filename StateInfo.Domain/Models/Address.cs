using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateInfo.Domain.Models
{
	[Table("address", Schema = "state_organizations")]
	public class Address
	{
		[Key]
		public Guid Id { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
	}
}
