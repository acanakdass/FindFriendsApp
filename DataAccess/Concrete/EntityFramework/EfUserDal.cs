using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfUserDal : EfEntityRepositoryBase<User, LocatorContext>, IUserDal
   {
        //private HttpContextAccessor httpContext;

        //public EfUserDal(HttpContextAccessor httpContext)
        //{
        //    this.httpContext = httpContext;
        //}

        public List<OperationClaim> GetClaims(User user)
      {
         using (var context = new LocatorContext())
         {
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
         }
      }

        public List<UserWithLocationDto> GetUsersWithLocation(Expression<Func<UserWithLocationDto, bool>> filter = null)
        {
            using (LocatorContext context = new LocatorContext())
            {
                var result = from user in context.Users
                             join location in context.Locations on user.Id equals location.UserId
                             select new UserWithLocationDto
                             {
                                 Id = user.Id,
                                 Email=user.Email,
                                 FirstName=user.FirstName,
                                 LastName=user.LastName,
                                 Username=user.Username,
                                 Status=user.Status,
                                 Location=location
                             };
                if (filter == null)
                {
                    return result.ToList();
                }
                return result.Where(filter).ToList();
            }
        }

        //public User GetCurrentUser()
        //{
        //    var userId = httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    return this.Get(u => u.Id.ToString() == userId);
        //}
    }
}
