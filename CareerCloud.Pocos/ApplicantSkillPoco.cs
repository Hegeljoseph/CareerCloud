using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco
    {
        [Key]
        public Guid Id { get; set; }
        /*
         *Applicant
         *Skill
         * Skill_Level
         * Start_Month
         * Start_Year
         * End_Month
         * End_Year
         */

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
