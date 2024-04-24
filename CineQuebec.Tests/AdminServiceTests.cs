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
	public class AdminServiceTests
	{
		
        [Fact]
		public async Task ConnexionUtilisateur_UtilisateurTrouve_RetourneUtilisateur()
		{
			// Arrange
			Mock<IAdminRepository> mockAdminRepo = new Mock<IAdminRepository>();
			IAdminService authService = new AdminService(mockAdminRepo.Object);
			Administrateur expectedAdmin = new Administrateur { Name = "user", Password = new byte[16] };

			mockAdminRepo.Setup(repo => repo.ConnexionUtilisateur("user", It.IsAny<string>())).ReturnsAsync(expectedAdmin);

			// Act
			Administrateur? result = await authService.ConnexionUtilisateur("user", "password");

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedAdmin, result);
		}



		[Fact]
		public async Task ConnexionUtilisateur_UtilisateurNonTrouve_RetourneNull()
		{
			// Arrange
			Mock<IAdminRepository> mockAdminRepo = new Mock<IAdminRepository>();
			IAdminService authService = new AdminService(mockAdminRepo.Object);

			mockAdminRepo.Setup(repo => repo.ConnexionUtilisateur("user", It.IsAny<string>())).Throws<UtilisateurNotFoundException>();

			// Act
			Administrateur? result = await authService.ConnexionUtilisateur("user", "password");

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public async Task ConnexionUtilisateur_Erreur_RetourneNull()
		{
			// Arrange
			Mock<IAdminRepository> mockAdminRepo = new Mock<IAdminRepository>();
			IAdminService authService = new AdminService(mockAdminRepo.Object);

			mockAdminRepo.Setup(repo => repo.ConnexionUtilisateur("user", It.IsAny<string>())).Throws<Exception>();

			// Act
			Administrateur? result = await authService.ConnexionUtilisateur("user", "password");

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public async Task ConnexionUtilisateur_Appelle_HacherMotDePasse()
		{
			// Arrange
			Mock<IAdminRepository> mockRepo = new Mock<IAdminRepository>();
			IAdminService adminService = new AdminService(mockRepo.Object);

			string nom = "user";
			string password = "password";

			// Act
			Administrateur? result = await adminService.ConnexionUtilisateur(nom, password);

			// Assert
			mockRepo.Verify(repo => repo.ConnexionUtilisateur(nom, It.IsAny<string>()), Times.Once);
		}
	}
}
