﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestarauntReviews.DTO
{
    public class Restaraunt
    {
        public string BusinessName { get; set; }
        public string PriceRatings { get; set; }
        public List<Review> Reviews { get; set; }
        
    }
}