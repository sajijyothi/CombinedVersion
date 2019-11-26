using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Models.Master
{
    public class CompanyDet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CmpId { get; set; }

        [StringLength(100)]
        [Required]
        public string CompanyID { get; set; }//  It should be combination of Three Character -001 etc for eg SCN-001(SupplyChainNext)

        [StringLength(100)]
        [Required]
        public string CompName { get; set; }
        [StringLength(50)]
        [Required]
        public string CompCode { get; set; }
        [StringLength(50)]
        [Required]
        public string CompTrnNo { get; set; }
        [StringLength(200)]
        [Required]
        public string CompAddress { get; set; }
        [ForeignKey("CompCity")]
        public int CompCity { get; set; }
        public virtual City City { get; set; }
        [NotMapped]
        public string CityName { get; set; }
        [ForeignKey("CompState")]
        public int CompState { get; set; }
        public virtual State State { get; set; }
        [NotMapped]
        public string StateName { get; set; }
        [ForeignKey("CompCountry")]
        public int CompCountry { get; set; }
        public virtual Country Country { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [StringLength(50)]
        [Required]
        public string CompZipCode { get; set; }
        [StringLength(50)]
        [Required]
        public string CompPrefPhoneNo { get; set; }

        [StringLength(50)]
        [Required]
        public string CompAltPhoneNo { get; set; }
        [StringLength(50)]
        [Required]
        public string CompContactName { get; set; }

        [StringLength(50)]
        [Required]
        public string CompRefNameNo { get; set; }
        public int CompLoginEnable { get; set; }
        [StringLength(200)]
        [Required]
        public string CompAddress2 { get; set; }
        [StringLength(150)]
        [DisplayName("Upload File")]
        public string compLogo{ get; set; }

        
        // `CompLogo` blob,

        public int OrgTypeID { get; set; }//It should be from organization type
        [StringLength(15)]
        [Required]
        public string OrgID { get; set; }// It should be from organization Unit Master
        public int LicenseType { get; set; }
        public int UserLimit { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DefWorkStartTime { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DefWorkEndTime { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime FinStartDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime FinEndDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime CmpTimeZone { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime CompBussinessHr { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime MaxWrkHr { get; set; }

        [StringLength(45)]
        [Required]
        public string TrnNo { get; set; }

        [StringLength(150)]
        [DisplayName("Upload File")]
        public string Logo { get; set; }
        //`Logo` longblob,
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ModifiedOn { get; set; }
        [StringLength(50)]
        public string IP { get; set; }
        public int Status { get; set; }
     
   

    }
}
