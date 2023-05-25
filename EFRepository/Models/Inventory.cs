using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public int BatchNo { get; set; }
      
        public int SellerId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ImportedDate { get; set; }
      
        public int StockQuantity { get; set; }
      
        public int StockLeft { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
      
        public string CreatedBy { get; set; }
      
        public bool IsActive { get; set; } = true;
        [ForeignKey("SellerId")]
        public SellerInfo SellerInfo { get; set; }

        public IList<ProductInfo> Products { get; set; }
    }
}
