using System.ComponentModel.DataAnnotations;


namespace GamesBoxd.Models
{
    public class GameList
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        [MaxLength(40, ErrorMessage = "O nome deve ter no máximo 40 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(280, ErrorMessage = "A descrição deve ter no máximo 280 caracteres.")]
        public string? Description { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public UserProfile User { get; set; }
        public List<GameListGame> GameListGames { get; set; } = new();
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; } = new();
    }
}