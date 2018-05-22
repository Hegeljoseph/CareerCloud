using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Work_History")]
    public class ApplicantWorkHistoryPoco
    {
        [Key]
        public Guid Id { get; set; }

        /*
         * Applicant
         * Company_Name
         * Country_Code
         *Location
         *Job_Title
         *Job_Description
         *Start_Month
         *Start_Year
         *End_Month
         *End_Year
         */

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
