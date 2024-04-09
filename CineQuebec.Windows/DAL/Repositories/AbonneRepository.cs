using CineQuebec.Windows.DAL.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Repositories
{
    public class AbonneRepository:BaseRepository
    {
      

        public AbonneRepository()
        {
          
        }

        public virtual List<Abonne> ObtenirAbonnes()
        {
            var abonnes = new List<Abonne>();

            try
            {
                IMongoCollection<Abonne> collection = database.GetCollection<Abonne>("Abonnes");
                abonnes = collection.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return abonnes;
        }
    }
}
