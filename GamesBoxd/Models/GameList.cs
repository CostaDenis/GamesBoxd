using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesBoxd.Models
{
    public class GameList
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public UserProfile User { get; set; }
        public List<GameListGame> GameListGames { get; set; } = new();
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; } = new();
    }
}