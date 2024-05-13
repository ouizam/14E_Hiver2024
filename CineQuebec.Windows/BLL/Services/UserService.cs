using Amazon.Runtime.Internal.Transform;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Exceptions;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Konscious.Security.Cryptography;
using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.DAL.Interfaces;

namespace CineQuebec.Windows.BLL.Services
{
    public class UserService: IUserService
    {
        private  Dictionary<string, byte[]> _dicoSalts;
        private readonly IUserRepository _userRepository;
        private List<User> _user = new List<User>();

    
        public UserService(IUserRepository pUserRepo)
        {
            _userRepository = pUserRepo;
            _dicoSalts = new Dictionary<string, byte[]>();
        }
        /// <summary>
        /// Méthode qui assure la conexion avce un username et un mot de passe, elle fait appel a la méthode HacherMotde  passe pour et CreerSalt assurer
        /// une connexion sécurisé
        /// </summary>
        /// <param name="pUsername"></param>
        /// <param name="pPassword"></param>
        /// <returns></returns>
        public async Task<Abonne?> ConnexionUtilisateur(string pUsername, string pPassword)
        {
            try
            {              
                var salt = CreerSALT();
                byte[] pswordHache = HacherMotDePasse(pPassword, salt);
                return await  _userRepository.ConnexionUtilisateur(pUsername, pPassword);

            }catch (UtilisateurNotFoundException)
            {
                return null;
            }
            catch (Exception ex)
            {
				return null;
			}
		}
        /// <summary>
        /// Méthode pour hacher le mot de passe
        /// </summary>
        /// <param name="password"></param>
        /// <param name="pSalt"></param>
        /// <returns></returns>
        public  byte[] HacherMotDePasse(string password, byte[] pSalt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = pSalt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };

            return argon2.GetBytes(16);
        }
        public  byte[] CreerSALT()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
    }
}
