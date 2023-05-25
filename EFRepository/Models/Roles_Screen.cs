using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFRepository.Models
{
    public class Role_Screen
    {
        [Key, Column(Order = 0)]
        public int ScreenId { get; set; }

        [Key, Column(Order = 1)]
        public int RoleId { get; set; }

        public string CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool IsActive { get; set; }

        //public IList<Screen> Screens { get; set; }

        //public IList<Role> Roles { get; set; }
    }
}
