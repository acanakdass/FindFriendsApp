using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _friendsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getAllFriends")]
        public IActionResult GetAllFriendsByUserId(int userId)
        {
            return Ok(_friendsService.GetAllFriendsByUserId(userId));
        }

        [HttpGet("getAllFriendRequests")]
        public IActionResult GetAllFriendRequests(int userId)
        {
            return Ok(_friendsService.GetAllFriendRequests(userId));
        }

        [HttpGet("checkIfRequestAlreadySent")]
        public IActionResult checkIfRequestAlreadySent(int senderId,int receiverId)
        {
            var result = _friendsService.CheckIfFriendRequestAlreadySent(senderId, receiverId);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }

        [HttpPost("acceptFriendRequest")]
        public IActionResult AcceptFriendRequest([FromBody] SenderReceiverDto senderReceiverDto)
        {
            var result = _friendsService.AcceptFriendRequest(senderReceiverDto.SenderId, senderReceiverDto.ReceiverId);
            return Ok(result);
        }

        [HttpPost("removeFromFriends")]
        public IActionResult RemoveFromFriends([FromBody] SenderReceiverDto senderReceiverDto)
        {
            var result = _friendsService.RemoveFriend(senderReceiverDto.SenderId, senderReceiverDto.ReceiverId);
            return Ok(result);
        }

        [HttpPost("sendFriendRequest")]
        public IActionResult SendFriendRequest([FromBody] SenderReceiverDto senderReceiverDto)
        {
            var result = _friendsService.SendFriendRequest(senderReceiverDto.SenderId, senderReceiverDto.ReceiverId);
            return Ok(result);
        }
    }
}

