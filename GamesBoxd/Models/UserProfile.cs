using System.ComponentModel.DataAnnotations;


namespace GamesBoxd.Models
{
    public class UserProfile
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username é obrigatório.")]
        [MinLength(3, ErrorMessage = "Username deve ter pelo menos 3 caracteres.")]
        [MaxLength(20, ErrorMessage = "Username deve ter no máximo 20 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Username deve conter apenas letras e números.")]
        public string Name { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public List<Review> Reviews { get; set; } = new();
        public List<UserFriend> Friends { get; set; } = new();
        public List<UserGame> UserGames { get; set; } = new();
        public List<GameList> Lists { get; set; } = new();
    }
}