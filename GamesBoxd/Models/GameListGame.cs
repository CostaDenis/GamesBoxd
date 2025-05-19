using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesBoxd.Models
{
    public class GameListGame
    {
        public Guid Id { get; set; }
        public Guid GameListId { get; set; }
        public GameList GameList { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public int Order { get; set; }

    }
}