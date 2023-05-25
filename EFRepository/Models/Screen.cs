using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFRepository.Models
{
    public class Screen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string Name { get; set; }
      
        public DateTime CreatedDate { get; set; }
      
        public bool IsActive { get; set; }

        public IList<Role_Screen> Role_Screens { get; set; }
    }
}
