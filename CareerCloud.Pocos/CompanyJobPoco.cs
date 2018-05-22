using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs")]
    public class CompanyJobPoco
    {
        [Key]
        public Guid Id { get; set; }
        /*
         * Company
         *Profile_Created
         *Is_Inactive
         *Is_Company_Hidden
         *
         */

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

    }
}
