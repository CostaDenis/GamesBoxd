using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GamesBoxd.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserProfile User { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Comment? Comment { get; set; }
        public double Rating { get; set; }
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }
}