using System;

namespace FriendsApp.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        
        // cascaded to user, if user is deleted, photo will be deleted too
        public User User { get; set; }
        public int UserId { get; set; }
    }
}