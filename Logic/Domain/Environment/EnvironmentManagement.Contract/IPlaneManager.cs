﻿using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement.Contract
{
    [MapException(typeof(EnvironmentManagementException))]
    public interface IPlaneManager
    {
        IQueryable<Plane> GetAll();
        IQueryable<Plane> GetAllPlanesOfWorld(Guid worldId);
        Plane Get(Guid planeId);

        void Update(Plane plane);
        void Delete(Plane plane);
        void Add(Plane plane);
    }
}
