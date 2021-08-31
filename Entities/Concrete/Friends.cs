using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Friends:IEntity
    {
        public int Id { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public bool IsAccepted { get; set; }
    }
}

