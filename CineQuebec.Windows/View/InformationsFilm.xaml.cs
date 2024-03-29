using CineQuebec.Windows.DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CineQuebec.Windows.View
{
	/// <summary>
	/// Logique d'interaction pour InformationsFilm.xaml
	/// </summary>
	public partial class InformationsFilm : Window
	{
		private Film _film;
		public InformationsFilm(Film film)
		{
			InitializeComponent();
			_film = film;

			//DataContext = new
			//{
			//	PathProperties = new List<KeyValuePair<string, string>>
			//	{
			//		new KeyValuePair<string, string>("Id", film.Id.ToString()),
			//		new KeyValuePair<string, string>("Date de sortie", film.DateSortieFilm.ToString()),
			//		new KeyValuePair<string, string>("Est affiché", film.EstAffiche.ToString()),
			//		new KeyValuePair<string, string>("Nom", film.Nom.ToString()),
			//		new KeyValuePair<string, string>("Categorie", film.Categorie.NameCategorie.ToString()),
			//		new KeyValuePair<string, string>("Réalisateur(s)", string.Join(", ", film.Realisateurs)),
			//		new KeyValuePair<string, string>("Acteur(s)", string.Join(", ", film.Acteurs)),
			//	}
			//};
		}

	}
}
