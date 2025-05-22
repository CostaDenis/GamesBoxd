using System.ComponentModel.DataAnnotations;

namespace GamesBoxd.Models
{
    public class Game
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório.")]
        [MaxLength(60, ErrorMessage = "Título deve no máximo 60 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição é obrigatória.")]
        [MinLength(10, ErrorMessage = "Descrição deve no mínimo 10 caracteres.")]
        [MaxLength(500, ErrorMessage = "Descrição deve no máximo 500 caracteres.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Desenvolvedor é obrigatório.")]
        [MinLength(3, ErrorMessage = "Desenvolvedor deve no mínimo 3 caracteres.")]
        [MaxLength(40, ErrorMessage = "Desenvolvedor deve no máximo 40 caracteres.")]
        public string Developer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Publicador é obrigatória.")]
        [MinLength(3, ErrorMessage = "Publicador deve no mínimo 3 caracteres.")]
        [MaxLength(40, ErrorMessage = "Publicador deve no máximo 40 caracteres.")]
        public string Publisher { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de lançamento é obrigatória.")]
        public DateTime ReleaseDate { get; set; }
        public List<Genre> Genres { get; set; } = new();

        [Required(ErrorMessage = "Plataforma é obrigatória.")]
        public List<GamePlatform> GamePlatforms { get; set; } = new();

        [Range(0, 10)]
        public double AverageRanting { get; set; }
        public List<UserGame> UserGames { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();

    }
}