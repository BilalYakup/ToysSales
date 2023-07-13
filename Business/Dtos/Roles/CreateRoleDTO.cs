using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Roles
{
	public class CreateRoleDTO
	{
		[Required, MinLength(3, ErrorMessage = "en az 3 karakter giriniz")]
		public string Name { get; set; }
	}
}
