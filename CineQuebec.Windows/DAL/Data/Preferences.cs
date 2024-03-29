using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
   public class Preferences
    {
        public ObjectId Id { get; set; }
        public ObjectId IdAbonne { get; set; }
        public ObjectId IdActeur { get; set; }
        public ObjectId IdRealisateur { get; set; }
        public ObjectId IdCategorie { get; set; }
    }
}
