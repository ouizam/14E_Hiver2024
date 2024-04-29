using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Reservation
    {
		public ObjectId Id { get; init; } = ObjectId.GenerateNewId();
		public DateTime DateReservation { get; set; }
        public Abonne Abonne { get; set; }
        public Projection Projection { get; set; }
        
        public string Siege { get; set; }

        public Reservation() { }

        public Reservation(Projection pProjection, Abonne pAbonne, string pSiege)
        { 
            DateReservation = DateTime.Now;
            Projection = pProjection;
            Abonne = pAbonne;
            Siege = pSiege;
        }

    }
}
