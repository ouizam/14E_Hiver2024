using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Recompense
    {
        public ObjectId Id { get; set; }
        public TypeRecompense Type { get; set; }
        //public Abonne Abonne { get; set; }
    }
}
