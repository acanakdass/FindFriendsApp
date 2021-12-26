using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Location:IEntity
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int UserId { get; set; }
    }
}

