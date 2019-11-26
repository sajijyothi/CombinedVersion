using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Models.Master
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        [StringLength(80)]
        public string CityName { get; set; }

        [StringLength(10)]
        public string CityCode { get; set; }
        
        [ForeignKey("StateId")]
        public int StateId { get; set; }

        [NotMapped]
        [StringLength(80)]
        public string StateName { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }

        [NotMapped]
        [StringLength(80)]
        public string CountryName { get; set; }

        public int Status { get; set; }

        [StringLength(50)]
        public string CompanyID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ModifiedOn { get; set; }
        [StringLength(50)]
        public string IP { get; set; }

    }
}
