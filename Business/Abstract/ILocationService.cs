using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILocationService
    {
        IDataResult<Location> GetById(int id);
        IDataResult<List<Location>> GetAll();
        IResult Add(Location location);
        IResult Update(Location location);
        IResult Delete(Location location);
        IResult CreateOrUpdate(Location location);
    }
}

