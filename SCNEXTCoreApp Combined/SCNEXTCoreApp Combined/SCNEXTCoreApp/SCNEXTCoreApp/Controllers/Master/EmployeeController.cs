using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using SCNEXTCoreApp.Data.Constant;
using SCNEXTCoreApp.Data.Master;
using SCNEXTCoreApp.Models.Master;
using static SCNEXTCoreApp.Models.ViewModel.UserDetails;

namespace SCNEXTCoreApp.Controllers.Master
{
    public class EmployeeController : Controller
    {
        private readonly GeneralDbContext _context;
       private readonly IHostingEnvironment hostingEnvironment;

        public EmployeeController(IHostingEnvironment hostingEnvironment,GeneralDbContext context)
        {
            this.hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET: Employee
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Employees.ToListAsync());
        //}

        public IActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == "EmployeeName")
                return View(_context.Employees.Where(m => m.EmpFirstName == search || search == null)
                    .ToPagedList(page ?? 1, 3));
            else
                return View(_context.Employees.Where(m => m.EmpCode == search || search == null)
                    .ToPagedList(page ?? 1, 3));
        }


        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewBag.Country = new SelectList(_context.country, "CountryId", "CountryName");
            return View(new Employee());
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpFirstName,EmpMiddleName,EmpLastName,Gender,EmpCode,DOB,ImagePath,Profession,Designation,DOJ,YearOfexp,BasicSalary,HRAAmt,TransportAmt,OtherAllowanceAmt,Address,PermanentAddress,ContactNo,LandlineNo,EmergencyNo,Email,FaxNo,HomeLandNo,Extension,PostCode,LanguageId,CurrencyId,StateId,CityId,CountryId,VisaNo,VisaStatus,VisaIssueDate,VisaExpDate,ExpatNo,InsCardNo,InsExpDate,LicIssueDate,LicExpiryDate,InsProviderID,EmiratesId,IdentificationDocID,LicenseType,LicenseNo,LicenseIssuePlace,VehicleNo,Weburl,PassportNo,PlaceOfIssue,EmpDirectStatus,EmpIndirectSupID,LastAnnualLeave,DateofResign,DateofRelieve,EmpStartDate,EmpEndDate,BranchId,RepToMangr,CompanyEmail,NationalityID,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Employee employee,IFormFile file)
        {
            if (ModelState.IsValid)
            {



                employee.Status = AppConstant.Active;
                employee.CompanyID = AppConstant.CompanyID;
                employee.CreatedOn = DateTime.Now;
                employee.ModifiedOn = DateTime.Now;
                employee.IP = GetIPAddress.getExternalIp();
                _context.Add(employee);
                await _context.SaveChangesAsync();
                // Code to upload image
                if (file != null || file.Length != 0)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    var newFilename = employee.EmpId + "_" + String.Format("{0:d}", (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                    var webPath = hostingEnvironment.WebRootPath;
                    var path = Path.Combine("", webPath + @"\ImageFiles\" + newFilename);
                    var pathToSave = @"/ImageFiles/" + newFilename;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    employee.ImagePath = pathToSave;
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }



        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Country = new SelectList(_context.country, "CountryId", "CountryName");
            var employee = await _context.Employees.FindAsync(id);            
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("EmpId,EmpFirstName,EmpMiddleName,EmpLastName,Gender,EmpCode,DOB,ImageUrl,Profession,Designation,DOJ,YearOfexp,BasicSalary,HRAAmt,TransportAmt,OtherAllowanceAmt,Address,PermanentAddress,ContactNo,LandlineNo,EmergencyNo,Email,FaxNo,HomeLandNo,Extension,PostCode,LanguageId,CurrencyId,StateId,CityId,CountryId,VisaNo,VisaStatus,VisaIssueDate,VisaExpDate,ExpatNo,InsCardNo,InsExpDate,LicIssueDate,LicExpiryDate,InsProviderID,EmiratesId,IdentificationDocID,LicenseType,LicenseNo,LicenseIssuePlace,VehicleNo,Weburl,PassportNo,PlaceOfIssue,EmpDirectStatus,EmpIndirectSupID,LastAnnualLeave,DateofResign,DateofRelieve,EmpStartDate,EmpEndDate,BranchId,RepToMangr,CompanyEmail,NationalityID,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Employee employee)
        {
            if (ModelState.IsValid)
            {

                employee.ModifiedOn = DateTime.Now;
                employee.IP = GetIPAddress.getExternalIp();
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(employee);
        }

        

        // GET: Employee/Delete/5        
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetState(int CountryId)
        {
            List<State> StateList = new List<State>();
            StateList = (from s in _context.state
                         where s.CountryId == CountryId
                         select s).ToList();
            StateList.Insert(0, new State { StateId = 0, StateName = "Select Any" });
            return Json(new SelectList(StateList, "StateId", "StateName"));
        }

        public JsonResult GetCity(int StateId)
        {
            List<City> CityList = new List<City>();
            CityList = (from ct in _context.city
                         where ct.StateId == StateId
                         select ct).ToList();
            CityList.Insert(0, new City { CityId = 0, CityName = "Select Any" });
            return Json(new SelectList(CityList, "CityId", "CityName"));
        }
    }
}
