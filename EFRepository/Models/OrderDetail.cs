using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public decimal Price { get; set; }
      
        public int ProductId { get; set; }
      
        public int OrderId { get; set; }
      
        public DateTime OrderDate { get; set; }
      
        public string OrderBy { get; set; }
      
        public bool IsActive { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public ProductInfo ProductInfo { get; set; }
    }
}
