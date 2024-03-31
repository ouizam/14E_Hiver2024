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

namespace CineQuebec.Windows.BLL.Services
{
    public class AdminService
    {
        private  Dictionary<string, byte[]> _dicoSalts;
        private AdminRepository _adminRepository;

        public AdminService()
        {
            _adminRepository = new AdminRepository();
            _dicoSalts = new Dictionary<string, byte[]>();
        }

        public AdminService(AdminRepository pAdminRepo)
        {
            _adminRepository = pAdminRepo;
            _dicoSalts = new Dictionary<string, byte[]>();
        }

        public async Task<Administrateur?> ConnexionUtilisateur(string pUsername, string pPassword)
        {
            try
            {
                
                byte[] pswordHache = HacherMotDePasse(pPassword);
                return await  _adminRepository.ConnexionUtilisateur(pUsername, pswordHache);

            }catch (UtilisateurNotFoundException)
            {
                return null;
            }
            catch (Exception ex)
            {
				return null;
			}
		}
        public  byte[] HacherMotDePasse(string password)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = CreerSALT(),
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
