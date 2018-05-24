using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
    public class SystemLanguageCodePoco
    {
        [Key]
        public Guid LanguageID { get; set; }

        public string Name { get; set; }

        [Column("Native_Name")]
        public string NativeName { get; set; }

    }
}
