using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Projection
    {
        public ObjectId Id { get; set; }
        public  DateTime DateProjection { get; set; }
        public int NoSalle { get; set; }
        public ObjectId IdFilm { get; set; }
        public Film Film { get; set; }
    }
}
