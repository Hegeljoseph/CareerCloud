using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Log")]
    public class SecurityLoginsLogPoco
    {
        [Key]
        public Guid Id { get; set; }

        /*
         * Login
         *Source_IP
         *Logon_Date
         *Is_Succesful
         */
    }
}
