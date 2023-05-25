using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public string Name { get; set; }

        public DateTime Createddate { get; set; }
      
        public string CreatedBy { get; set; }
      
        public bool IsActive { get; set; }

        public IList<ProductInfo> Products { get; set; }
    }
}
