using System.ComponentModel.DataAnnotations;

namespace GamesBoxd.Models
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;
        public List<Game> Games { get; set; } = new();
    }
}