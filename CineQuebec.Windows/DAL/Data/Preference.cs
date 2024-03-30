﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
   public class Preference
    {
        public ObjectId Id { get; set; }
        public ObjectId IdAbonne { get; set; }
        public ObjectId IdActeur { get; set; }
        public ObjectId IdRealisateur { get; set; }
        public ObjectId IdCategorie { get; set; }
        public Acteur Acteur { get; set; }
        public Realisateur Realisateur { get; set; }
        public Categorie Categorie { get; set; }
    }
}
