using CineQuebec.Windows.BLL.Interfaces;
using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.BLL.Services
{
    public class ProjectionService: IProjectionService
    {
        private ProjectionRepository _projectionRepository;

        public ProjectionService()
        {
            _projectionRepository = new ProjectionRepository();
        }
        public ProjectionService(ProjectionRepository projectionRepository)
        {
            _projectionRepository = projectionRepository;
        }

        /// <summary>
        /// Obtiens la Projection associé à l'ID passé en paramètre.
        /// </summary>
        /// <param name="idProjection">L'ID de la Projection</param>
        /// <returns>Une Projectiom</returns>
        public virtual Projection ObtenirProjection(ObjectId idProjection)
        {
            var projection = new Projection();

            try
            {
                projection = _projectionRepository.ObtenirProjection(idProjection);
              
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection " + ex.Message, "Erreur");
            }
            return projection;
        }

        /// <summary>
        /// Obtiens une liste de tous les Projections contenuent dans la base de donnée.
        /// </summary>
        /// <returns>Une Liste des Projections ou null si une Exception est survenue</returns>
        public virtual async Task<List<Projection>?> GetAllProjections()
        {
            try
            {
                return await _projectionRepository.GetAllProjections();
            }catch (Exception ex)
            {
                Console.WriteLine("Impossible de recuperer les Projections: ", ex.Message, "Erreur");
            }
            return null;
        }
    }
}
