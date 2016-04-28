﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Bikes.Model;
using System.Drawing;

namespace Bikes.Api
{
    public class RiderSummaryController : BikesApiControllerBase
    {
        [HttpGet]
        [Route("api/rider/{riderId:int}/RiderSummary/{month:int}")]
        public JObject Get(int riderId, int month)
        {
            //get the rides for this month
            IEnumerable<Ride> rides = Ride.getRides().Where(r => r.ride_date.Month == DateTime.Now.Month);
            if (riderId > 0)
            {
                rides = rides.Where(r => r.rider_id == riderId);
            }

            IEnumerable<IGrouping<int, Ride>> groups = rides.GroupBy(r => r.rider_id);

            IEnumerable<Rider> riders = Rider.getRiders();
            if (riderId > 0)
            {
                riders = riders.Where(r => r.id == riderId);
            }

            JObject recentRides = new JObject(
                new JProperty("labels",
                    new JArray(DateTime.Now.ToString("MMMM"))),
                new JProperty("datasets",
                    new JArray(groups.Select(g => 
                        new JObject(
                            new JProperty("label", g.riderName(riders)),
                            new JProperty("fillColor", g.chartColor(riders, 112)),
                            new JProperty("strokeColor", g.chartColor(riders, 200)),
                            new JProperty("highlightFill", g.chartColor(riders, 180)),
                            new JProperty("highlightStroke", g.chartColor(riders, 255)),
                            new JProperty("data",
                                new JArray(Math.Round( 
                                    g.Sum(r => r.distance), 2)
                                    )))))));


            App.BikesDebug.dumpToFile("recentRides.json", recentRides.ToString(Newtonsoft.Json.Formatting.Indented));

            return recentRides;
        }
    }
}
