﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Reservation
    {
        public ObjectId Id {  get; set; }
        public DateTime DateReservation { get; set; }
        public ObjectId IdAbonne { get; set; }
        public ObjectId IdProjection { get; set; }
        public Projection Projection { get; set; }
    }
}