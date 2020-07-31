using System;

namespace Users.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLogin { get; set; }
    }
}