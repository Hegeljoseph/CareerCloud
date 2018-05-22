using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins")]
    public class SecurityLoginPoco
    {
        [Key]
        public Guid Id { get; set; }
        /*
         *Login
         *Password
         *Created_Date
         *Password_Update_Date
         *Agreement_Accepted_Date
         *Is_Locked
         *Is_Inactive
         *Email_Address
         * Phone_Number
         *Full_Name
         *Force_Change_Password
         *Prefferred_Language
         *
         */

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

    }
}
