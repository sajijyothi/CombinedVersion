using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace SCNEXTCoreApp.Models.Master
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }

        [StringLength(100)]
        public string EmpFirstName { get; set; }

        [StringLength(100)]
        public string EmpMiddleName { get; set; }

        [StringLength(100)]
        public string EmpLastName { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(30)]
        public string EmpCode { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DOB { get; set; }

        [StringLength(150)]
        public string ImagePath { get; set; }

        [StringLength(100)]
        public string Profession { get; set; }

        [StringLength(100)]
        public string Designation { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DOJ { get; set; }

        public int YearOfexp { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal HRAAmt { get; set; }

        public decimal TransportAmt { get; set; }

        public decimal OtherAllowanceAmt { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string PermanentAddress { get; set; }

        [StringLength(50)]
        public string ContactNo { get; set; }

        [StringLength(100)]
        public string LandlineNo { get; set; }

        [StringLength(100)]
        public string EmergencyNo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string FaxNo { get; set; }

        [StringLength(100)]
        public string HomeLandNo { get; set; }

        public string Extension { get; set; }

        public string PostCode { get; set; }

        public int LanguageId { get; set; }

        public int CurrencyId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

        public int CountryId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string VisaNo { get; set; }

        [StringLength(100)]
        public string VisaStatus { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime VisaIssueDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime VisaExpDate { get; set; }

        [StringLength(100)]
        public string ExpatNo { get; set; }

        [StringLength(100)]
        public string InsCardNo { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime InsExpDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime LicIssueDate { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime LicExpiryDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string InsProviderID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string EmiratesId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string IdentificationDocID { get; set; }

        public string LicenseType { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LicenseNo { get; set; }

        [StringLength(100)]
        public string LicenseIssuePlace { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string VehicleNo { get; set; }

        public string Weburl { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PassportNo { get; set; }

        [StringLength(100)]
        public string PlaceOfIssue { get; set; }

        public string EmpDirectStatus { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string EmpIndirectSupID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime LastAnnualLeave { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DateofResign { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DateofRelieve { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime EmpStartDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime EmpEndDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string BranchId { get; set; }

        public string RepToMangr { get; set; }

        [StringLength(50)]
        public string CompanyEmail { get; set; }
        public int NationalityID { get; set; }

        [StringLength(150)]
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
