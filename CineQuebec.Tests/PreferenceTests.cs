using CineQuebec.Windows.BLL.Services;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Tests
{
    public class PreferenceTests
    {
        Mock<PreferenceRepository> mockRepo = new Mock<PreferenceRepository>();
        [Fact]
        public void ObtenirPreference_ById()
        {
          
            ObjectId idPreference = ObjectId.GenerateNewId();
            Preference preference = new Preference { Id = idPreference };
            mockRepo.Setup(x => x.ObtenirePreference(idPreference)).Returns(preference);
            PreferenceService prefernceService = new PreferenceService(mockRepo.Object);

            //act
            Preference result = prefernceService.ObtenirPreference(idPreference);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(preference.Id, result.Id);
        }

        [Fact]
        public void Obtenir_Preferences_De_Chaque_Abonne_By_Id_Abonne()
        {
            Mock<RealisateurService> realisateurService = new Mock<RealisateurService>();
            Mock<ActeurService> acteurService = new Mock<ActeurService>();
            Mock<CategorieService> categorieService = new Mock<CategorieService>();
            Mock<AbonneRepository> abonneRepo = new Mock<AbonneRepository>();

            ObjectId realisateurId = ObjectId.GenerateNewId();
            Realisateur realiasteur = new Realisateur { Id = realisateurId };
            realisateurService.Setup(x => x.ObtenirUnRealisateur(realisateurId)).Returns(realiasteur);

            ObjectId acteurId = ObjectId.GenerateNewId();
            Acteur acteur = new Acteur {  Id = acteurId };
            acteurService.Setup(y => y.ObtenirUnActeur(acteurId)).Returns(acteur);

            ObjectId categorieId = ObjectId.GenerateNewId();
            Categorie categorie = new Categorie {  Id = categorieId };
            categorieService.Setup(z =>z.ObtenirCategorie(categorieId)).Returns(categorie);

            List<Preference> preferences = new List<Preference>() { new Preference { Acteur = acteur, Categorie = categorie, Realisateur = realiasteur }, new Preference { Acteur = acteur, Categorie = categorie, Realisateur = realiasteur } };


            ObjectId abonneId = ObjectId.GenerateNewId();
            Abonne abonne = new Abonne {  Id = abonneId };
            mockRepo.Setup(i => i.ObtenirPreferencesAbonne(abonneId)).Returns(preferences);

            //Act
            PreferenceService preferenceService = new PreferenceService(mockRepo.Object, acteurService.Object, realisateurService.Object, categorieService.Object);
            List<Preference> resultat = preferenceService.ObtenirPreferencesAbonne(abonneId);

            //Assert
            Assert.NotNull(resultat);
            Assert.Equal(preferences.Count, resultat.Count);
            Assert.Equal(preferences[0].Id, resultat[0].Id);
            Assert.Equal(preferences[0].Acteur, resultat[0].Acteur);
            Assert.Equal(preferences[0].Realisateur, resultat[0].Realisateur);
            Assert.Equal(preferences[0].Categorie, resultat[0].Categorie);
        }
    }
}
