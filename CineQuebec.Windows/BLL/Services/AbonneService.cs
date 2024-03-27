using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.BLL.Services
{
    public class AbonneService
    {
        private AbonneRepository _abonneRepository;
        private ReservationService _reservationService;

        public AbonneService()
        {
            _abonneRepository = new AbonneRepository();
            _reservationService = new ReservationService();
        }
        public List<Abonne> ReadAbonnes()
        {
            var abonnes = new List<Abonne>();

            try
            {
                abonnes = _abonneRepository.ReadAbonnes();
                foreach (var abonne in abonnes)
                {
                    abonne.Reservations = _reservationService.ObtenirReservationsAbonne(abonne.Id);
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return abonnes;
        }
    }
}
