using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesBoxd.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public List<string> Genres { get; set; } = new();
        public double AverageRanting { get; set; }
        public List<UserGame> UserGames { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();

    }
}