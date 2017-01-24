using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    
    public class OperationResult
    {
       
        public virtual int Id { get; set; }
        
        public virtual int ArgumentCount { get; set; }
        
        [MaxLength(50)]
        public virtual string Arguments { get; set; }
        
        [MaxLength(50)]
        public virtual string Result { get; set; }
       
        public virtual long ExetTimeMs { get; set; }
        
        public virtual int OperationId { get; set; }

        public virtual int UserId { get; set; }

        public virtual Users Users { get; set; }

        public virtual Operation Operation { get; set; }

    }
}