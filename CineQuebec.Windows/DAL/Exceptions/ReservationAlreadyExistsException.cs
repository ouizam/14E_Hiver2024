using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Exceptions
{
	public class ReservationAlreadyExistsException: Exception
	{

		public ReservationAlreadyExistsException() { }
		public ReservationAlreadyExistsException(string message) : base(message) { }
	}
}
