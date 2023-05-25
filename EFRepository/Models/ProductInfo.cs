using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Models
{
    public class ProductInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public string Name { get; set; }
      
        public string Description { get; set; }
      
        public string Dimesions { get; set; }
      
        public string Price { get; set; }
      
        public string FileFolder { get; set; }
      
        public string FilePath { get; set; }
      
        public string Type { get; set; }
      
        public string Weight { get; set; }
      
        public int CategoryId { get; set; }
        
        public int InventoryId { get; set; }
      
        public DateTime CreatedDate { get; set; }
      
        public DateTime CreatedBy { get; set; }
      
        public bool IsActive { get; set; } = true;

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("InventoryId")]
        public Inventory Inventory { get; set; }

        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
