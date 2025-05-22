using System.ComponentModel.DataAnnotations;

namespace GamesBoxd.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public UserProfile User { get; set; }

        [Required]
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Comment? Comment { get; set; }

        [Required(ErrorMessage = "A nota é obrigatória.")]
        [Range(0, 10)]
        public double Rating { get; set; }
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}