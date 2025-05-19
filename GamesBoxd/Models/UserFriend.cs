using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesBoxd.Models
{
    public class UserFriend
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserProfile User { get; set; }
        public Guid FriendId { get; set; }
        public UserProfile Friend { get; set; }
    }
}