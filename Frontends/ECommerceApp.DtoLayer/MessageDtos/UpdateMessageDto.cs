﻿namespace ECommerceApp.DtoLayer.MessageDtos
{
    public class UpdateMessageDto
    {
        public int UserMessageId { get; set; }
        public string SendedId { get; set; }
        public string ReciecerId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool IsRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}