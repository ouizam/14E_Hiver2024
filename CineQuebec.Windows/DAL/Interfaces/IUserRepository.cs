using CineQuebec.Windows.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<Abonne> ConnexionUtilisateur(string pUsername, string pPassword);
       
    }
}
