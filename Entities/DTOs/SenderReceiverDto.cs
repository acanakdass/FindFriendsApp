using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class SenderReceiverDto:IDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}

