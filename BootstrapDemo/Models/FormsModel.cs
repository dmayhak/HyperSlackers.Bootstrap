using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Bootstrap.Demo.Models
{
    public class FormsModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsHappy { get; set; }

        public DateTime SignUpDate { get; set; }

        public ColorType FavoriteColor { get; set; }

        public string Description { get; set; }
    }
}
