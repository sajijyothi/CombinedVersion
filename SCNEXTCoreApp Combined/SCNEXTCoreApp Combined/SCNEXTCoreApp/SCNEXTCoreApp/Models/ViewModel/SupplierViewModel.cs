using SCNEXTCoreApp.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Models.ViewModel
{
    public class SupplierViewModel
    {
        //public Supplier Supplier { get; set; }
        //public Address Address { get; set; }
        public string SupName { get; set; }
        public string SupCode { get; set; }
        public string SupTrnNo { get; set; }   
        public string SupLoginEnable { get; set; }        
        public int TypeId { get; set; } //Supplier = 1;Customer = 2;
        public int SupID { get; set; } //SupplierId - typereferenceid
        public string AddressAprtNo { get; set; }        
        public string AddressFloorNo { get; set; }        
        public string AddressBuildingNo { get; set; }      
        public string AddressBuildingName { get; set; }
        public string AddressStreetName { get; set; }   
        public string AddressStreetNo { get; set; }
        public string AddressAreaCode { get; set; }
        public string AddressAreaName { get; set; }
        public string AddressCity { get; set; }
        public string AddressDistrict { get; set; }        
        public string AddressState { get; set; }       
        public string AddressCountry { get; set; }
        public string AddressContactNo1 { get; set; }       
        public string AddressContactNo2 { get; set; }       
        public string AddressEmailId1 { get; set; }       
        public string AddressEmailId2 { get; set; }
        public string AddressContactPerson1 { get; set; }        
        public string AddressContactPerson2 { get; set; }        
        public string AddressLatLoc { get; set; }       
        public string AddressLongLoc { get; set; }       
        public string AddressUrl { get; set; }
        public string AddressClosestLandMark { get; set; }     
        public string AddressField1 { get; set; }
        public string AddressField2 { get; set; }
        public string AddressField3 { get; set; }        
        public string AddressField4 { get; set; }        
        public string AddressField5 { get; set; }
        public int Status { get; set; }        
        public string CompanyID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string IP { get; set; }

    }
}
