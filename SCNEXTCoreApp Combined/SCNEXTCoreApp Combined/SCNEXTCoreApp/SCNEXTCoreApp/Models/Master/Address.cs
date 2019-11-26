using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Models.Master
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("CustId")]
        public int TypeRefId { get; set; }

        [StringLength(50)]
        public string AddressAprtNo { get; set; }

        [StringLength(50)]
        public string AddressFloorNo { get; set; }

        [StringLength(50)]
        public string AddressBuildingNo { get; set; }

        [StringLength(50)]
        public string AddressBuildingName { get; set; }

        [StringLength(50)]
        public string AddressStreetName { get; set; }

        [StringLength(50)]
        public string AddressStreetNo { get; set; }

        [StringLength(50)]
        public string AddressAreaCode { get; set; }

        [StringLength(50)]
        public string AddressAreaName { get; set; }

        [StringLength(50)]
        public string AddressCity { get; set; }

        [StringLength(50)]
        public string AddressDistrict { get; set; }

        [StringLength(50)]
        public string AddressState { get; set; }

        [StringLength(50)]
        public string AddressCountry { get; set; }

        [StringLength(50)]
        public string AddressContactNo1 { get; set; }

        [StringLength(50)]
        public string AddressContactNo2 { get; set; }

        [StringLength(50)]
        public string AddressEmailId1 { get; set; }

        [StringLength(50)]
        public string AddressEmailId2 { get; set; }

        [StringLength(50)]
        public string AddressContactPerson1 { get; set; }

        [StringLength(50)]
        public string AddressContactPerson2 { get; set; }

        [StringLength(50)]
        public string AddressLatLoc { get; set; }

        [StringLength(50)]
        public string AddressLongLoc { get; set; }

        [StringLength(250)]
        public string AddressUrl { get; set; }

        [StringLength(50)]
        public string AddressClosestLandMark { get; set; }

        [StringLength(50)]
        public string AddressField1 { get; set; }

        [StringLength(50)]
        public string AddressField2 { get; set; }

        [StringLength(50)]
        public string AddressField3 { get; set; }

        [StringLength(50)]
        public string AddressField4 { get; set; }

        [StringLength(50)]
        public string AddressField5 { get; set; }

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
