﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int id);
        IDataResult<User> GetCurrentUser();
        IDataResult<List<User>> SearchUserByUsername(string username);
        IDataResult<List<UserWithLocationDto>> GetAllUsersWithLocations();
        IDataResult<UserWithLocationDto> GetUserWithLocation(int userId);
        IDataResult<string> UploadUserImage(IFormFile formFile,int userId);

    }
}
