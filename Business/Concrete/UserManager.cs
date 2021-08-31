using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.IoC;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        private IHttpContextAccessor _httpContextAccessor;


        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<User>> GetAll()
        {
            var users =_userDal.GetAll();
            return new SuccessDataResult<List<User>>(users, Messages.Listed);
        }

        public IDataResult<User> GetById(int id)
        {
            var user = _userDal.Get(u => u.Id== id);
            return new SuccessDataResult<User>(user, Messages.Listed);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(user,Messages.Listed);
        }

        public IDataResult<User> GetByUsername(string username)
        {
            var user = _userDal.Get(u => u.Username==username);
            return new SuccessDataResult<User>(user, Messages.Listed);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result, Messages.Listed);
        }

        public IDataResult<User> GetCurrentUser()
        {
            var result = _httpContextAccessor.HttpContext.User.Identities.FirstOrDefault();
            if (result.Claims.Count() > 0)
            {
                var userId = result.Claims.FirstOrDefault().Value;
                //var userMail = result.Claims.ElementAt(1).Value;
                //var userName = result.Claims.ElementAt(2).Value;
                //var userRole = result.Claims.ElementAt(3).Value;

                var currentUserResult = GetById(Int32.Parse(userId));
                if (currentUserResult.Success)
                {
                    return new SuccessDataResult<User>(currentUserResult.Data, Messages.Listed);
                }
            }
            return new ErrorDataResult<User>(Messages.UserNotFound);
            //return new ErrorDataResult<IEnumerable<ClaimsIdentity>>(null,Messages.NotFound);
        }

        public IDataResult<List<User>> SearchUserByUsername(string username)
        {
            var result = _userDal.GetAll(u => u.Email.ToLower().Contains(username)|| u.FirstName.ToLower().Contains(username) || u.Username.ToLower().Contains(username));
            return new SuccessDataResult<List<User>>(result,Messages.Listed);
        }
        //public IDataResult<User> GetCurrentUser()
        //{
        //    var result = _userDal.GetCurrentUser();
        //    return new SuccessDataResult<User>(result, Messages.Listed);
        //}
    }
}
