using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails=new List<OrderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public decimal TotalAmount { get; set; }
      
        public int CustomerId { get; set; }

      
        public DateTime OrderDate { get; set; }
      
        public string OrderBy { get; set; }
      
        public bool IsActive { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
