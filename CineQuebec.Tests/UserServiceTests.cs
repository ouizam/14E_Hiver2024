using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL.Exceptions;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.BLL.Interfaces;

namespace CineQuebec.Tests
{
	public class UserServiceTests
	{
		
        [Fact]
		public async Task ConnexionUtilisateur_UtilisateurTrouve_RetourneUtilisateur()
		{
			// Arrange
			Mock<IUserRepository> mockAdminRepo = new Mock<IUserRepository>();
			IUserService authService = new UserService(mockAdminRepo.Object);
			Abonne expectedAdmin = new Abonne { Name = "user", Password = new byte[16] };

			mockAdminRepo.Setup(repo => repo.ConnexionUtilisateur("user", It.IsAny<string>())).ReturnsAsync(expectedAdmin);

            // Act
            User? result = await authService.ConnexionUtilisateur("user", "password");

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedAdmin, result);
		}



		[Fact]
		public async Task ConnexionUtilisateur_UtilisateurNonTrouve_RetourneNull()
		{
			// Arrange
			Mock<IUserRepository> mockAdminRepo = new Mock<IUserRepository>();
			IUserService authService = new UserService(mockAdminRepo.Object);

			mockAdminRepo.Setup(repo => repo.ConnexionUtilisateur("user", It.IsAny<string>())).Throws<UtilisateurNotFoundException>();

            // Act
            User? result = await authService.ConnexionUtilisateur("user", "password");

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public async Task ConnexionUtilisateur_Erreur_RetourneNull()
		{
			// Arrange
			Mock<IUserRepository> mockAdminRepo = new Mock<IUserRepository>();
			IUserService authService = new UserService(mockAdminRepo.Object);

			mockAdminRepo.Setup(repo => repo.ConnexionUtilisateur("user", It.IsAny<string>())).Throws<Exception>();

            // Act
            User? result = await authService.ConnexionUtilisateur("user", "password");

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public async Task ConnexionUtilisateur_Appelle_HacherMotDePasse()
		{
			// Arrange
			Mock<IUserRepository> mockRepo = new Mock<IUserRepository>();
			IUserService adminService = new UserService(mockRepo.Object);

			string nom = "user";
			string password = "password";

            // Act
            User? result = await adminService.ConnexionUtilisateur(nom, password);

			// Assert
			mockRepo.Verify(repo => repo.ConnexionUtilisateur(nom, It.IsAny<string>()), Times.Once);
		}
	}
}
