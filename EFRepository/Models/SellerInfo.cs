using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Models
{
    public class SellerInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public string CompanyName { get; set; }
      
        public string Address { get; set; }
        public string Address2 { get; set; }
      
        public string City { get; set; }
      
        public string State { get; set; }
      
        public string Zip { get; set; }
      
        public string Email { get; set; }
      
        public string Contact { get; set; }
        public string AlternateContact { get; set; }
      
        public DateTime CreatedDate { get; set; }
      
        public bool IsActive { get; set; }
        public IList<Inventory> Inventories { get; set; }
    }
}
