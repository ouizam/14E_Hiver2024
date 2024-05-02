using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Exceptions
{
	public class ProjectionNotFoundException: Exception
	{
		public ProjectionNotFoundException() { }
		public ProjectionNotFoundException(string message): base(message) { }

	}
}
