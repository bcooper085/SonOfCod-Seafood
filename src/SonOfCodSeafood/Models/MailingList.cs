using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SonOfCodSeafood.Models
{
    [Table("MailingLists")]
    public class MailingList
    {
        [Key]
        public int MailingListId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public virtual User User { get; set; }
    }
}
