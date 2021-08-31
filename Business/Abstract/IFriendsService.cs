using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFriendsService
    {
        IDataResult<Friends> GetById(int id);
        IDataResult<List<Friends>> GetAll();
        IResult Add(Friends friends);
        IResult Update(Friends friends);
        IResult Delete(Friends friends);
        IResult SendFriendRequest(int userSenderId,int userReceiverId);
        IResult AcceptFriendRequest(int userSenderId,int userReceiverId);
        IResult RemoveFriend(int userSenderId,int userReceiverId);
        IDataResult<List<User>>GetAllFriendsByUserId(int userId);
        IDataResult<List<User>>GetAllFriendRequests(int userId);
        IResult CheckIfFriendRequestAlreadySent(int userSenderId,int userReceiverId);
    }
}

