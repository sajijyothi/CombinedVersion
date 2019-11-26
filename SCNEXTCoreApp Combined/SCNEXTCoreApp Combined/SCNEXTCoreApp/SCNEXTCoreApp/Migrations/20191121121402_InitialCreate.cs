using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCNEXTCoreApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(nullable: false),
                    TypeRefId = table.Column<int>(nullable: false),
                    AddressAprtNo = table.Column<string>(maxLength: 50, nullable: true),
                    AddressFloorNo = table.Column<string>(maxLength: 50, nullable: true),
                    AddressBuildingNo = table.Column<string>(maxLength: 50, nullable: true),
                    AddressBuildingName = table.Column<string>(maxLength: 50, nullable: true),
                    AddressStreetName = table.Column<string>(maxLength: 50, nullable: true),
                    AddressStreetNo = table.Column<string>(maxLength: 50, nullable: true),
                    AddressAreaCode = table.Column<string>(maxLength: 50, nullable: true),
                    AddressAreaName = table.Column<string>(maxLength: 50, nullable: true),
                    AddressCity = table.Column<string>(maxLength: 50, nullable: true),
                    AddressDistrict = table.Column<string>(maxLength: 50, nullable: true),
                    AddressState = table.Column<string>(maxLength: 50, nullable: true),
                    AddressCountry = table.Column<string>(maxLength: 50, nullable: true),
                    AddressContactNo1 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressContactNo2 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressEmailId1 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressEmailId2 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressContactPerson1 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressContactPerson2 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressLatLoc = table.Column<string>(maxLength: 50, nullable: true),
                    AddressLongLoc = table.Column<string>(maxLength: 50, nullable: true),
                    AddressUrl = table.Column<string>(maxLength: 250, nullable: true),
                    AddressClosestLandMark = table.Column<string>(maxLength: 50, nullable: true),
                    AddressField1 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressField2 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressField3 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressField4 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressField5 = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandName = table.Column<string>(maxLength: 100, nullable: true),
                    BrandCode = table.Column<string>(maxLength: 30, nullable: true),
                    MfrId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(maxLength: 80, nullable: true),
                    CityCode = table.Column<string>(maxLength: 10, nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(maxLength: 80, nullable: true),
                    CountryCode = table.Column<string>(maxLength: 10, nullable: true),
                    callingCode = table.Column<string>(maxLength: 8, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustName = table.Column<string>(maxLength: 200, nullable: true),
                    CustCode = table.Column<string>(maxLength: 50, nullable: true),
                    CustTrnNo = table.Column<string>(maxLength: 50, nullable: true),
                    CustLoginEnable = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustId);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    DeptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "DgClassDangerous",
                columns: table => new
                {
                    DgClassDangerousId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DgClassDangerousName = table.Column<string>(maxLength: 80, nullable: true),
                    DgClassDangerousCode = table.Column<string>(maxLength: 10, nullable: true),
                    DgClassDangerousDescription = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DgClassDangerous", x => x.DgClassDangerousId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpFirstName = table.Column<string>(maxLength: 100, nullable: true),
                    EmpMiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    EmpLastName = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    EmpCode = table.Column<string>(maxLength: 30, nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 150, nullable: true),
                    Profession = table.Column<string>(maxLength: 100, nullable: true),
                    Designation = table.Column<string>(maxLength: 100, nullable: true),
                    DOJ = table.Column<DateTime>(nullable: false),
                    YearOfexp = table.Column<int>(nullable: false),
                    BasicSalary = table.Column<decimal>(nullable: false),
                    HRAAmt = table.Column<decimal>(nullable: false),
                    TransportAmt = table.Column<decimal>(nullable: false),
                    OtherAllowanceAmt = table.Column<decimal>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    PermanentAddress = table.Column<string>(maxLength: 100, nullable: true),
                    ContactNo = table.Column<string>(maxLength: 50, nullable: true),
                    LandlineNo = table.Column<string>(maxLength: 100, nullable: true),
                    EmergencyNo = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    FaxNo = table.Column<string>(maxLength: 100, nullable: true),
                    HomeLandNo = table.Column<string>(maxLength: 100, nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    VisaNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    VisaStatus = table.Column<string>(maxLength: 100, nullable: true),
                    VisaIssueDate = table.Column<DateTime>(nullable: false),
                    VisaExpDate = table.Column<DateTime>(nullable: false),
                    ExpatNo = table.Column<string>(maxLength: 100, nullable: true),
                    InsCardNo = table.Column<string>(maxLength: 100, nullable: true),
                    InsExpDate = table.Column<DateTime>(nullable: false),
                    LicIssueDate = table.Column<DateTime>(nullable: false),
                    LicExpiryDate = table.Column<DateTime>(nullable: false),
                    InsProviderID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmiratesId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IdentificationDocID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LicenseType = table.Column<string>(nullable: true),
                    LicenseNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LicenseIssuePlace = table.Column<string>(maxLength: 100, nullable: true),
                    VehicleNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Weburl = table.Column<string>(nullable: true),
                    PassportNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PlaceOfIssue = table.Column<string>(maxLength: 100, nullable: true),
                    EmpDirectStatus = table.Column<string>(nullable: true),
                    EmpIndirectSupID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastAnnualLeave = table.Column<DateTime>(nullable: false),
                    DateofResign = table.Column<DateTime>(nullable: false),
                    DateofRelieve = table.Column<DateTime>(nullable: false),
                    EmpStartDate = table.Column<DateTime>(nullable: false),
                    EmpEndDate = table.Column<DateTime>(nullable: false),
                    BranchId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    RepToMangr = table.Column<string>(nullable: true),
                    CompanyEmail = table.Column<string>(maxLength: 50, nullable: true),
                    NationalityID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "EmpSkillSet",
                columns: table => new
                {
                    EmpSkillSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpSkillSetName = table.Column<string>(maxLength: 100, nullable: true),
                    EmpSkillSetCode = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpSkillSet", x => x.EmpSkillSetId);
                });

            migrationBuilder.CreateTable(
                name: "HSCode",
                columns: table => new
                {
                    HSCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSCode", x => x.HSCodeId);
                });

            migrationBuilder.CreateTable(
                name: "jobStatus",
                columns: table => new
                {
                    JobStatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobStatName = table.Column<string>(maxLength: 100, nullable: true),
                    JobStatCode = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobStatus", x => x.JobStatId);
                });

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    MfrId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MfrName = table.Column<string>(maxLength: 100, nullable: true),
                    MfrCode = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.MfrId);
                });

            migrationBuilder.CreateTable(
                name: "OUType",
                columns: table => new
                {
                    OUTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OUType", x => x.OUTypeID);
                });

            migrationBuilder.CreateTable(
                name: "pimcategory",
                columns: table => new
                {
                    PimCatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Code = table.Column<string>(maxLength: 45, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    VatStatus = table.Column<int>(nullable: false),
                    VatType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pimcategory", x => x.PimCatID);
                });

            migrationBuilder.CreateTable(
                name: "ReOrderingFlowFreq",
                columns: table => new
                {
                    ReOrderingFlowFreqId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReOrderingFlowFreqName = table.Column<string>(maxLength: 80, nullable: true),
                    ReOrderingFlowFreqCode = table.Column<string>(maxLength: 10, nullable: true),
                    ReOrderingFlowFreqDescription = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReOrderingFlowFreq", x => x.ReOrderingFlowFreqId);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(maxLength: 80, nullable: true),
                    StateCode = table.Column<string>(maxLength: 10, nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupName = table.Column<string>(maxLength: 100, nullable: false),
                    SupCode = table.Column<string>(maxLength: 100, nullable: false),
                    SupTrnNo = table.Column<string>(maxLength: 100, nullable: false),
                    SupLoginEnable = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupID);
                });

            migrationBuilder.CreateTable(
                name: "taxmaster",
                columns: table => new
                {
                    TaxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaxName = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Rate = table.Column<double>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxmaster", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "Uom",
                columns: table => new
                {
                    UomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uom", x => x.UomId);
                });

            migrationBuilder.CreateTable(
                name: "VehBrand",
                columns: table => new
                {
                    VehBrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehBrandName = table.Column<string>(maxLength: 80, nullable: true),
                    VehBrandCode = table.Column<string>(maxLength: 10, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehBrand", x => x.VehBrandId);
                });

            migrationBuilder.CreateTable(
                name: "VehGearType",
                columns: table => new
                {
                    VehGearTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehGearTypeName = table.Column<string>(maxLength: 100, nullable: false),
                    VehGearTypeCode = table.Column<string>(maxLength: 30, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehGearType", x => x.VehGearTypeId);
                });

            migrationBuilder.CreateTable(
                name: "vehicleLicenceType",
                columns: table => new
                {
                    VehLicTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehLicTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    VehLicTypeCode = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleLicenceType", x => x.VehLicTypeId);
                });

            migrationBuilder.CreateTable(
                name: "vehicletype",
                columns: table => new
                {
                    VehtypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicletype", x => x.VehtypeId);
                });

            migrationBuilder.CreateTable(
                name: "VehMake",
                columns: table => new
                {
                    VehMakeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehMakeName = table.Column<string>(maxLength: 80, nullable: true),
                    VehMakeCode = table.Column<string>(maxLength: 10, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehMake", x => x.VehMakeId);
                });

            migrationBuilder.CreateTable(
                name: "vehowner",
                columns: table => new
                {
                    VehOwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Code = table.Column<string>(maxLength: 45, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehowner", x => x.VehOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "VehOwnrType",
                columns: table => new
                {
                    VehOwnrTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehOwnrTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    VehOwnrTypeCode = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehOwnrType", x => x.VehOwnrTypeId);
                });

            migrationBuilder.CreateTable(
                name: "VehPermit",
                columns: table => new
                {
                    VehPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehPermitName = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehPermit", x => x.VehPermitId);
                });

            migrationBuilder.CreateTable(
                name: "VehPlatePrefix",
                columns: table => new
                {
                    VehPlatePrefixId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehPlatePrefixName = table.Column<string>(maxLength: 80, nullable: true),
                    VehPlatePrefixCode = table.Column<string>(maxLength: 10, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehPlatePrefix", x => x.VehPlatePrefixId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    MangerID = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    Address2 = table.Column<string>(maxLength: 200, nullable: false),
                    PostCode = table.Column<string>(maxLength: 45, nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    ContactPer = table.Column<string>(maxLength: 200, nullable: false),
                    ContPerMobNo = table.Column<string>(maxLength: 45, nullable: false),
                    ContPerEmail = table.Column<string>(maxLength: 45, nullable: false),
                    WMFaxNo = table.Column<string>(maxLength: 45, nullable: false),
                    WMDepartmentId = table.Column<int>(nullable: false),
                    DepartmentDeptId = table.Column<int>(nullable: true),
                    WMTeleNo = table.Column<string>(maxLength: 45, nullable: false),
                    WMEmail = table.Column<string>(maxLength: 45, nullable: false),
                    WMUrl = table.Column<string>(maxLength: 45, nullable: false),
                    WMCurrencyId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouse_currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouse_department_DepartmentDeptId",
                        column: x => x.DepartmentDeptId,
                        principalTable: "department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pimcategorytype",
                columns: table => new
                {
                    PimCatTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Code = table.Column<string>(maxLength: 45, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    VatStatus = table.Column<int>(nullable: false),
                    VatType = table.Column<int>(nullable: false),
                    PimCatID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pimcategorytype", x => x.PimCatTypeID);
                    table.ForeignKey(
                        name: "FK_pimcategorytype_pimcategory_PimCatID",
                        column: x => x.PimCatID,
                        principalTable: "pimcategory",
                        principalColumn: "PimCatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDet",
                columns: table => new
                {
                    CmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<string>(maxLength: 100, nullable: false),
                    CompName = table.Column<string>(maxLength: 100, nullable: false),
                    CompCode = table.Column<string>(maxLength: 50, nullable: false),
                    CompTrnNo = table.Column<string>(maxLength: 50, nullable: false),
                    CompAddress = table.Column<string>(maxLength: 200, nullable: false),
                    CompCity = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: true),
                    CompState = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    CompCountry = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    CompZipCode = table.Column<string>(maxLength: 50, nullable: false),
                    CompPrefPhoneNo = table.Column<string>(maxLength: 50, nullable: false),
                    CompAltPhoneNo = table.Column<string>(maxLength: 50, nullable: false),
                    CompContactName = table.Column<string>(maxLength: 50, nullable: false),
                    CompRefNameNo = table.Column<string>(maxLength: 50, nullable: false),
                    CompLoginEnable = table.Column<int>(nullable: false),
                    CompAddress2 = table.Column<string>(maxLength: 200, nullable: false),
                    compLogo = table.Column<string>(maxLength: 150, nullable: true),
                    OrgTypeID = table.Column<int>(nullable: false),
                    OrgID = table.Column<string>(maxLength: 15, nullable: false),
                    LicenseType = table.Column<int>(nullable: false),
                    UserLimit = table.Column<int>(nullable: false),
                    DefWorkStartTime = table.Column<DateTime>(nullable: false),
                    DefWorkEndTime = table.Column<DateTime>(nullable: false),
                    FinStartDate = table.Column<DateTime>(nullable: false),
                    FinEndDate = table.Column<DateTime>(nullable: false),
                    CmpTimeZone = table.Column<DateTime>(nullable: false),
                    CompBussinessHr = table.Column<DateTime>(nullable: false),
                    MaxWrkHr = table.Column<DateTime>(nullable: false),
                    TrnNo = table.Column<string>(maxLength: 45, nullable: false),
                    Logo = table.Column<string>(maxLength: 150, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDet", x => x.CmpId);
                    table.ForeignKey(
                        name: "FK_CompanyDet_city_CityId",
                        column: x => x.CityId,
                        principalTable: "city",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyDet_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyDet_state_StateId",
                        column: x => x.StateId,
                        principalTable: "state",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "binarea",
                columns: table => new
                {
                    binId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BinName = table.Column<string>(maxLength: 100, nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Remarks = table.Column<string>(maxLength: 150, nullable: false),
                    IsAc = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyID = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_binarea", x => x.binId);
                    table.ForeignKey(
                        name: "FK_binarea_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_binarea_WarehouseId",
                table: "binarea",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDet_CityId",
                table: "CompanyDet",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDet_CountryId",
                table: "CompanyDet",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDet_StateId",
                table: "CompanyDet",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_pimcategorytype_PimCatID",
                table: "pimcategorytype",
                column: "PimCatID");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CurrencyId",
                table: "Warehouse",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_DepartmentDeptId",
                table: "Warehouse",
                column: "DepartmentDeptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "binarea");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "CompanyDet");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "DgClassDangerous");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmpSkillSet");

            migrationBuilder.DropTable(
                name: "HSCode");

            migrationBuilder.DropTable(
                name: "jobStatus");

            migrationBuilder.DropTable(
                name: "manufacturer");

            migrationBuilder.DropTable(
                name: "OUType");

            migrationBuilder.DropTable(
                name: "pimcategorytype");

            migrationBuilder.DropTable(
                name: "ReOrderingFlowFreq");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "taxmaster");

            migrationBuilder.DropTable(
                name: "Uom");

            migrationBuilder.DropTable(
                name: "VehBrand");

            migrationBuilder.DropTable(
                name: "VehGearType");

            migrationBuilder.DropTable(
                name: "vehicleLicenceType");

            migrationBuilder.DropTable(
                name: "vehicletype");

            migrationBuilder.DropTable(
                name: "VehMake");

            migrationBuilder.DropTable(
                name: "vehowner");

            migrationBuilder.DropTable(
                name: "VehOwnrType");

            migrationBuilder.DropTable(
                name: "VehPermit");

            migrationBuilder.DropTable(
                name: "VehPlatePrefix");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "pimcategory");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
