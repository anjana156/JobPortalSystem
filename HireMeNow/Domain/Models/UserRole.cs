using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
<<<<<<< HEAD
    [Table("UserRoles")]

=======
    [Table("UserRole")]
>>>>>>> origin/nasilanasry
    public partial class UserRole
    {
        
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }

}
