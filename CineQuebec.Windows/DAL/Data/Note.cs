using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Note
    {
        public ObjectId Id { get; set; }
        public int NoteFilm {  get; set; }
        public Film Film { get; set; }
        public Abonne Abonne { get; set; }
        public Realisateur Realisateur { get; set; }
        public Acteur Acteur { get; set; }
        public Categorie Categorie { get; set; }
    }
}
