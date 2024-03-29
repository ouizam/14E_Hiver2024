using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Categorie
    {
        public ObjectId Id { get; set; }
        public string NameCategorie { get; set; }

		public Categorie(string pNom)
		{
			Id = ObjectId.GenerateNewId();
			NameCategorie = pNom;
		}

		public override string ToString()
		{
			return NameCategorie;
		}

	}
}
