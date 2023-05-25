using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string MidleNameName { get; set; }

        public string LastName { get; set; }

        public char Gender { get; set; }

        public string Address { get; set; }
        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string AlternateContact { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
