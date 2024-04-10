using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Acteur
    {
		public ObjectId Id { get; set; }
		public string NameActeur { get; set; }

		public Acteur() { }
		public Acteur(string pNom)
		{
			NameActeur = pNom;
			Id= ObjectId.GenerateNewId();
		}

		public override string ToString()
		{
			return NameActeur;
		}

		public override bool Equals(object obj)
		{
			if (obj is Acteur other)
			{
				return this.Id == other.Id;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode(); 
		}
	}
}
