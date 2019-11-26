using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Models.Master
{
    public class Uom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UomId { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(30)]
        [Required]
        //[Index(IsUnique = true)]
        public string Code { get; set; }
        [StringLength(150)]
        [Required]
        public string Description { get; set; }
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
