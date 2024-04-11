using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Realisateur
    {
        public ObjectId Id { get; set; }
        public string NameRealisateur { get; set; }

		public Realisateur() { }

		public Realisateur(string pNom)
		{ 
			NameRealisateur = pNom;
			Id= ObjectId.GenerateNewId();
		}
		public override bool Equals(object obj)
		{
			if (obj is Realisateur other)
			{
				return this.Id == other.Id;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override string ToString()
		{
			return NameRealisateur;
		}
	}
}
