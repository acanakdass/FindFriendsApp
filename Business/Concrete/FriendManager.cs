using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FriendsManager : IFriendsService

    {
        IFriendsDal _friendsDal;
        IUserService _userService;

        public FriendsManager(IFriendsDal friendsDal, IUserService userService)
        {
            _friendsDal = friendsDal;
            _userService = userService;
        }

        public IResult AcceptFriendRequest(int userSenderId, int userReceiverId)
        {
            var friends = _friendsDal.Get(f => f.User1Id == userSenderId && f.User2Id == userReceiverId);
            friends.IsAccepted = true;
            _friendsDal.Update(friends);
            return new SuccessResult(Messages.FriendRequestAccepted);
        }

        public IResult Add(Friends friends)
        {
            _friendsDal.Add(friends);
            return new SuccessResult(Messages.Added);
        }

        public IResult CheckIfFriendRequestAlreadySent(int userSenderId, int userReceiverId)
        {
            var result = _friendsDal.Get(f => (f.User1Id == userSenderId && f.User2Id == userReceiverId) && f.IsAccepted == false);
            if (result == null)
            {
                return new ErrorResult(Messages.FriendRequestAlreadySent);
            }
            return new SuccessResult();
        }

        public IResult Delete(Friends friends)
        {
            _friendsDal.Delete(friends);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<List<Friends>> GetAll()
        {
            return new SuccessDataResult<List<Friends>>(_friendsDal.GetAll());
        }

        public IDataResult<List<User>> GetAllFriendRequests(int userId)
        {
            var result = _friendsDal.GetAll(f => (f.User2Id == userId && f.IsAccepted==false));
            var requestingUsers = new List<User>();
            foreach (var friend in result)
            {
                var user = _userService.GetById(friend.User1Id);
                if (user.Success)
                {
                    requestingUsers.Add(user.Data);
                }
                
            }
            return new SuccessDataResult<List<User>>(requestingUsers);
        }

        public IDataResult<List<User>> GetAllFriendsByUserId(int userId)
        {
            var result = _friendsDal.GetAll(f => (f.User1Id == userId && f.IsAccepted) || (f.User2Id == userId && f.IsAccepted));
            var friends = new List<User>();
            foreach (var friend in result)
            {
                if (friend.User1Id == userId)
                {
                    var user = _userService.GetById(friend.User2Id);
                    if (user.Success)
                    {
                      friends.Add(user.Data);
                    }
                }
                else
                {
                    var user = _userService.GetById(friend.User1Id);
                    if (user.Success)
                    {
                      friends.Add(user.Data);
                    }
                }
            }
            return new SuccessDataResult<List<User>>(friends);
        }

        public IDataResult<Friends> GetById(int id)
        {
            return new SuccessDataResult<Friends>(_friendsDal.Get(f => f.Id == id));
        }

        public IResult RemoveFriend(int userSenderId, int userReceiverId)
        {

            var result = _friendsDal.Get(f => (f.User1Id == userSenderId && f.User2Id == userReceiverId) || f.User1Id == userReceiverId && f.User2Id == userSenderId);
            if (result != null)
            {
                _friendsDal.Delete(result);
                return new SuccessResult("Removed from friends");
            }
            return new ErrorResult("Error while removing user from friends");
        }

        public IResult SendFriendRequest(int userSenderId, int userReceiverId)
        {
            //Check if there is already a request between each other
            //var businessResult = BusinessRules.Run(checkIfFriendRequestAlreadySent(userSenderId,userReceiverId));

            //if (businessResult.Success)
            //{

            //}
            //else
            //{
            //    return new ErrorResult(businessResult.Message);
            //}
            _friendsDal.Add(new Friends
            {
                User1Id = userSenderId,
                User2Id = userReceiverId,
                IsAccepted = false
            });
            return new SuccessResult(Messages.FriendRequestSent);
        }

        public IResult Update(Friends friends)
        {
            _friendsDal.Update(friends);
            return new SuccessResult(Messages.Updated);
        }

        //Business Rule Methods
        private IResult checkIfFriendRequestAlreadySent(int senderId,int receiverId)
        {
            var result = _friendsDal.Get(f=>(f.User1Id == senderId && f.User2Id == receiverId)&&f.IsAccepted==false);
            if (result == null)
            {
                return new ErrorResult(Messages.FriendRequestAlreadySent);
            }
            return new SuccessResult();
        }
    }
}

