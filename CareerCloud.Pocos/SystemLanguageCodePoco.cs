using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
    public class SystemLanguageCodePoco
    {
        [Key]
        public Guid LanguageID { get; set; }

        /*
         * Name
         *Native_Name
         */
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

    }
}
