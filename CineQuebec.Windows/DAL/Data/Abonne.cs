using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace CineQuebec.Windows.DAL.Data
{
    public class Abonne:IDetailFilm
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public DateTime DateAdhesion { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public  List <Recompense> Recompenses { get; set; } = new List<Recompense>();


        public override string ToString()
        {
            return $"{Username}: adhéré(e) le {DateAdhesion}";
        }

        public void VoirDetailFilm(Film film)
        {
            throw new NotImplementedException();
        }
    }

  
}
