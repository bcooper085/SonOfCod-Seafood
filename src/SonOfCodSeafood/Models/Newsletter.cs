using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SonOfCodSeafood.Models
{
    [Table("Newsletters")]
    public class Newsletter
    {
        [Key]
        public int NewsletterId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public virtual User User { get; set; }
    }
}
