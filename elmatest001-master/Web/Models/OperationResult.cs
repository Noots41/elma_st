using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    [Table("OperationResult")]
    public class OperationResult
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Кол-во аргументов")]
        public int ArgumentCount { get; set; }

        [DisplayName("Аргументы")]
        [MaxLength(50)]
        public string Arguments { get; set; }

        [DisplayName("Результат")]
        [MaxLength(50)]
        public string Result { get; set; }

        [DisplayName("Время")]
        public long ExetTimeMs { get; set; }
       
        public int OperationId { get; set; }
       
        public Operations Operation { get; set; }

    }
}