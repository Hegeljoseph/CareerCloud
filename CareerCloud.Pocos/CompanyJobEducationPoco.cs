using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Educations")]
    public class CompanyJobEducationPoco
    {
        [Key]
        public Guid Id { get; set; }

        /*
         * Job
         * Major
         * Importance
         */
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

    }
}
