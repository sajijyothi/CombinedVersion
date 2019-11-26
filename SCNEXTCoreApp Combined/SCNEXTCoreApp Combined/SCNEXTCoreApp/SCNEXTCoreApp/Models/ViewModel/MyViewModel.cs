using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Models.ViewModel
{
    public class MyViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustId { get; set; }

        [StringLength(200)]
        public string CustName { get; set; }

        [StringLength(50)]
        public string CustCode { get; set; }

        [StringLength(50)]
        public string CustTrnNo { get; set; }

        public int CustLoginEnable { get; set; }

        public int TypeId { get; set; }

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
    }
}
