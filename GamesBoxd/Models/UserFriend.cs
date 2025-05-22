using System.ComponentModel.DataAnnotations;

namespace GamesBoxd.Models
{
    public class UserFriend
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public UserProfile User { get; set; }

        [Required]
        public Guid FriendId { get; set; }
        public UserProfile Friend { get; set; }
    }
}