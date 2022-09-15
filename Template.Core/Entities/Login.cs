using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Entities
{
    public class Login
    {
        [Required]
        public String Email { get; set; }
      
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }        
    }
}
