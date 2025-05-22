using System.ComponentModel.DataAnnotations;
using GamesBoxd.Enums;

namespace GamesBoxd.Models
{
    public class UserGame
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public UserProfile User { get; set; }

        [Required]
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Required(ErrorMessage = "O status do jogo é obrigatório.")]
        public EGameStatus Status { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}