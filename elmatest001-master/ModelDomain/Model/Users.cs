using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
   
    public class Users
    {
        
        public virtual int Id { get; set; }
        
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

    }
}