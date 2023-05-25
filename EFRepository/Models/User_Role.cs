using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFRepository.Models
{
    public class User_Role
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int RoleId { get; set; }
      
        public DateTime CreatedDate { get; set; }
      
        public bool IsActive { get; set; }
        public User User { get; set; }
        public Role Roles { get; set; }
    }
}
