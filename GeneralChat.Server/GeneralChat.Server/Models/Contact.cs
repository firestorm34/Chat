﻿namespace GeneralChat.Server.Models
{
    public class Contact
    {
        [Key]
        public int OwnerId { get; set; }
        public int ContactId { get; set; }

        public User Owner { get; set; } = new();
        public User ContactUser { get; set; } = new();
    }
}
