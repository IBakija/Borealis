using Borealis.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Borealis.Models
{
	public class TimeRegistrationViewModel
	{
		[Required]
		public String Name { get; set; }
		[Required]
		public String Surname { get; set; }
		[Required]
		public String Time { get; set; }

		public IEnumerable<Participants> Participants { get; set; }
	}
}