﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bikes.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bikes.App
{
    public class RiderVM
    {
        [HiddenInput]
        public int id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "please enter the name of the rider")]
        public String name { get; set; }

        [Display(Name = "Pence per mile")]
        [Required(ErrorMessage = "please enter the rate per mile")]
        public int rate { get; set; }


        public RiderVM()
        {
        }

        public RiderVM(Rider rider)
            : this()
        {
            id = rider.id;
            name = rider.name;
            rate = rider.rate;
        }

        public Rider toRider()
        {
            Rider rider = new Rider();

            rider.id = id;
            rider.name= name;
            rider.rate = rate;
            return rider;
        }

    }
}