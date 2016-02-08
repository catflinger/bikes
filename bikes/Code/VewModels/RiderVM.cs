﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bikes.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Bikes.Model.Banking;

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

        [Display(Name = "Bank username")]
        public String bankUsername { get; set; }

        [Display(Name = "Bank account number")]
        public String bankAccountNumber { get; set; }

        [Required(ErrorMessage = "please enter the colour for display in charts")]
        public int red { get; set; }

        [Required(ErrorMessage = "please enter the colour for display in charts")]
        public int green { get; set; }

        [Required(ErrorMessage = "please enter the colour for display in charts")]
        public int blue { get; set; }

        public RiderVM()
        {
            red = 220;
            green = 220;
            blue = 220; 
        }

        public RiderVM(Rider rider)
            : this()
        {
            id = rider.id;
            name = rider.name;
            rate = rider.rate;

            red = rider.color.R;
            green = rider.color.G;
            blue = rider.color.B;

            bankUsername = rider.bank_username == null ? "" : rider.bank_username;
            bankAccountNumber = rider.bank_account_id == Bank.DefaultAccountId ? "" : rider.bank_account_id.ToString();
        }

        public Rider toRider()
        {
            Rider rider = new Rider();

            rider.id = id;
            rider.name= name;
            rider.rate = rate;
            rider.color = System.Drawing.Color.FromArgb(255, red, green, blue);
            rider.bank_username = bankUsername == null ? bankUsername : bankUsername.Trim();
            rider.bank_account_id = Bank.DefaultAccountId;

            int accountId;
            if (int.TryParse(bankAccountNumber, out accountId))
            {
                rider.bank_account_id = accountId;
            }

            return rider;
        }

    }
}