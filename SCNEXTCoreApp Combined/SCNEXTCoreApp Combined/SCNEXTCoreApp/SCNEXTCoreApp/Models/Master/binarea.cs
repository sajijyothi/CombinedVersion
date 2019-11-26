using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Models.Master
{
    public class binarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int binId { get; set; }

        [StringLength(100)]
        [Required]
        public string BinName { get; set; }

        [ForeignKey("WarehouseId")]
        public int WarehouseId { get; set; }
        public virtual Warehouse  Warehouse { get; set; }
        [NotMapped]
        public string WarehouseName { get; set; }

        [StringLength(30)]
        [Required]
        public string Code { get; set; }
        [StringLength(150)]
        [Required]
        public string Remarks { get; set; }
        public int IsAc { get; set; }
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
