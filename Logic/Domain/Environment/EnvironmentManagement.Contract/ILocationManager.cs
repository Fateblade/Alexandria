﻿using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement.Contract
{
    [MapException(typeof(EnvironmentManagementException))]
    public interface ILocationManager
    {
        IQueryable<Location> GetAll();
        IQueryable<Location> GetSubLocationsOf(Guid locationId);
        Location Get(Guid locationId);

        void Update(Location location);
        void Delete(Location location);
        void Add(Location location);
    }
}
