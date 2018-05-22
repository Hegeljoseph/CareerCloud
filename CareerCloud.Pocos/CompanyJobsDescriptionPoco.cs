using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs_Descriptions")]
    public class CompanyJobsDescriptionPoco
    {
        [Key]
        public Guid Id { get; set; }
        /*
         * Job
         * Job_Name
         * Job_Descriptions
         */
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

    }
}
