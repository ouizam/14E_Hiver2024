using CineQuebec.Windows.DAL.Data;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Interfaces
{
    internal interface ICategorieRepository
    {
        Categorie ObtenirCategorie(ObjectId idCategorie);
        Task<List<Categorie>> GetAllCategories();
    }
}
