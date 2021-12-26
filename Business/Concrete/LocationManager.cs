using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LocationManager:ILocationService
    {
        ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public IResult Add(Location location)
        {
            _locationDal.Add(location);
            return new SuccessResult(Messages.Added);
        }

        public IResult CreateOrUpdate(Location location)
        {
            var locationData = _locationDal.Get(l => l.UserId == location.UserId);
            if(locationData==null)
            {
                return this.Add(location);
            }else
            {
                location.Id = locationData.Id;
                return this.Update(location);
            }
        }

        public IResult Delete(Location location)
        {
            _locationDal.Delete(location);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<List<Location>> GetAll()
        {
            return new SuccessDataResult<List<Location>>(_locationDal.GetAll());
        }

        public IDataResult<Location> GetById(int id)
        {
            var result = _locationDal.Get(l => l.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Location>(Messages.NotFound);
            }
            return new SuccessDataResult<Location>(result,Messages.Listed);
        }

        public IResult Update(Location location)
        {
            _locationDal.Update(location);
            return new SuccessResult(Messages.Updated);
        }
    }
}

