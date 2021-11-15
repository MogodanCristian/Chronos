using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChronosClient.Models
{
    class User
    {
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public static explicit operator HttpContent(User v)
        {
            throw new NotImplementedException();
        }
    }
}