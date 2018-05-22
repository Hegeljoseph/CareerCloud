using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Profiles")]
    public class CompanyProfilePoco
    {
        [Key]
        public Guid Id { get; set; }

        /*
         * Zip_Postal_Code
         *Company_Website
         *Contact_Phone
         *Contact_Name
         *Company_Logo
         */
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

    }
}
