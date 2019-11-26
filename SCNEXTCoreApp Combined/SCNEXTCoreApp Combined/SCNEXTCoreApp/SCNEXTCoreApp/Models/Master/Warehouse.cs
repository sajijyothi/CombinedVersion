using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Models.Master
{
    public class Warehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(30)]
        [Required]

        public string Code { get; set; }
        public int BranchId { get; set; }
        public int MangerID { get; set; }

        [StringLength(200)]
        [Required]
        public string Address { get; set; }
        [StringLength(200)]
        [Required]
        public string Address2 { get; set; }
        [StringLength(45)]
        [Required]
        public string PostCode { get; set; }
        [ForeignKey("StateId")]
        public int StateId { get; set; }
     //   public virtual State State { get; set; }
        [NotMapped]
        public string stateName { get; set; }
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
     //   public virtual Country Country { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        //public virtual City City { get; set; }
        [NotMapped]
        public string CityName { get; set; }
        [StringLength(200)]
        [Required]
        public string ContactPer { get; set; }
        [StringLength(45)]
        [Required]
        public string ContPerMobNo { get; set; }
        [StringLength(45)]
        [Required]
        public string ContPerEmail { get; set; }
        [StringLength(45)]
        [Required]
        public string WMFaxNo { get; set; }
        [ForeignKey("DepartmentId")]
        public int WMDepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }
        [StringLength(45)]
        [Required]
        public string WMTeleNo { get; set; }
        [StringLength(45)]
        [Required]
        public string WMEmail { get; set; }
        [StringLength(45)]
        [Required]
        public string WMUrl { get; set; }
        [ForeignKey("CurrencyId")]
        public int WMCurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        [NotMapped]
        public string CurrencyName { get; set; }

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
