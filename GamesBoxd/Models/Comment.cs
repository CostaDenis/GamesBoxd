using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesBoxd.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserProfile User { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Likes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}