using System.ComponentModel.DataAnnotations;

namespace GamesBoxd.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public UserProfile User { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [MinLength(3, ErrorMessage = "O título deve ter no mínimo 3 caracteres.")]
        [MaxLength(20, ErrorMessage = "O título deve ter no máximo 20 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "O texto é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O texto deve ter no máximo 250 caracteres.")]
        public string Text { get; set; } = string.Empty;
        public int Likes { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool? HasSpoiler { get; set; }

    }
}