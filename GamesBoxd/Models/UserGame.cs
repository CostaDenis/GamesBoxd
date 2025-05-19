using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesBoxd.Enums;

namespace GamesBoxd.Models
{
    public class UserGame
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserProfile User { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public EGameStatus Status { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}