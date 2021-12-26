using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<UserWithLocationDto> GetUsersWithLocation(Expression<Func<UserWithLocationDto, bool>> filter = null);
        //User GetCurrentUser();
    }
}
