using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class TypeRecompense
    {
        public ObjectId Id { get; set; }    
        public string nomRecompense {  get; set; }
    }
}
