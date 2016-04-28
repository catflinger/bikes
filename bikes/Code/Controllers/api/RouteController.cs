﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Bikes.Model;

namespace Bikes.Api
{
    public class RouteApiController : BikesApiControllerBase
    {
        [HttpGet]
        [Route("api/route")]
        public IEnumerable<Route> Get()
        {
            return Route.getRoutes();
        }

        [HttpGet]
        [Route("api/route/{id:int}")]
        public Route Get(int id)
        {
            return Route.getRoute(id);
        }

        [HttpPost]
        [Route("api/route")]
        public Route Post(Route route)
        {
            route.save();
            return route;
        }

        [HttpPost]
        [Route("api/route/{id:int}")]
        public Route Post(int id, Route route)
        {
            route.save();
            return route;
        }

        [HttpDelete]
        [Route("api/route/{id:int}")]
        public int Delete(int id)
        {
            Route.deleteRoute(id);
            return id;
        }

    }
}