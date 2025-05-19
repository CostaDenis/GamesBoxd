using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesBoxd.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public List<Review> Reviews { get; set; } = new();
        public List<UserFriend> Friends { get; set; } = new();
        public List<UserGame> UserGames { get; set; } = new();
        public List<GameList> Lists { get; set; } = new();
    }
}