using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills")]
    public class CompanyJobSkillPoco
    {
        [Key]
        public Guid Id { get; set; }

        /*
         *Job
         *Skill
         *Skill_Level
         *Importance
         */

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
