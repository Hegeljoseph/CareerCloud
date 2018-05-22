using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Roles")]
    public class SecurityRolePoco
    {
        [Key]
        public Guid Id { get; set; }
        /*
         *Role
         *Is_Inactive
         */

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

    }
}
