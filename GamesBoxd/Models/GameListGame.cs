using System.ComponentModel.DataAnnotations;

namespace GamesBoxd.Models
{
    public class GameListGame
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid GameListId { get; set; }
        public GameList GameList { get; set; }

        [Required]
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A ordem deve ser um número positivo.")]
        public int Order { get; set; }
    }
}