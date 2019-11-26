using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Models.Master
{
    public class pimcategorytype
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PimCatTypeID { get; set; } 

        [StringLength(45)]
        [Required]
        public string Name { get; set; }

        [StringLength(45)]
        [Required]
        public string Code { get; set; }
        [StringLength(150)]
        [Required]
        public string Description { get; set; }

         [StringLength(50)]
        public string CompanyID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }


        [StringLength(50)]
        public string IP { get; set; }
      
        public int VatStatus { get; set; }       
        public int VatType { get; set; }
        [ForeignKey("PimCatID")]
        public int PimCatID { get; set; }     
        public virtual pimcategory pimcategory { get; set; }
        [NotMapped]
        public string pimcategoryName { get; set; }

       
        
    }

}
