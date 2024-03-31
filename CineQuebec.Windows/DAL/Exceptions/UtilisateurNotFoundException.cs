using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Exceptions
{
	public  class UtilisateurNotFoundException : Exception
	{
		public UtilisateurNotFoundException() { }
		public UtilisateurNotFoundException(string message) : base(message) { }
		public UtilisateurNotFoundException(string message, Exception innerException) : base(message, innerException) { }
	}
}
