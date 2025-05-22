using System.ComponentModel.DataAnnotations;
using GamesBoxd.Enums;

namespace GamesBoxd.Models
{
    public class GamePlatform
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Required]
        public EPlatform Platform { get; set; }
    }
}