using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    public class CompanyLocationPoco
    {
        [Key]
        public Guid Id { get; set; }

        /*
         *Company
         *Country_Code
         *State_Province_Code
         *Street_Address
         *City_Town
         *Zip_Postal_Code
         */
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

    }
}
