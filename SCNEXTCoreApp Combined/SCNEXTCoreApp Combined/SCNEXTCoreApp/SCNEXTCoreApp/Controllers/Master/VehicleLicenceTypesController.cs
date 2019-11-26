using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCNEXTCoreApp.Data.Constant;
using SCNEXTCoreApp.Data.Master;
using SCNEXTCoreApp.Models.Master;
using static SCNEXTCoreApp.Models.ViewModel.UserDetails;
using PagedList.Core;

namespace SCNEXTCoreApp.Controllers.Master
{
    public class VehicleLicenceTypesController : Controller
    {
        private readonly GeneralDbContext _context;

        public VehicleLicenceTypesController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: VehicleLicenceTypes
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.vehicleLicenceType.ToListAsync());
        //}
        public IActionResult Index(string searchBy, string search,int? page)
        {
            if (searchBy == "VehLicTypeName")
                return View(_context.vehicleLicenceType.Where(m => m.VehLicTypeName == search || search == null).ToPagedList(page??1, 3));
            else
                return View(_context.vehicleLicenceType.Where(m => m.VehLicTypeCode == search || search == null).ToPagedList(page??1, 3));

        }


        // GET: VehicleLicenceTypes/Create
        public IActionResult Create()
        {
            return View(new VehicleLicenceType());
        }

        // POST: VehicleLicenceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehLicTypeId,VehLicTypeName,VehLicTypeCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehicleLicenceType vehicleLicenceType)
        {
            if (_context.vehicleLicenceType.Any(m => m.VehLicTypeCode.Equals(vehicleLicenceType.VehLicTypeCode)))
            {
                ModelState.AddModelError("", "[" + vehicleLicenceType.VehLicTypeCode + "]already exists");
            }

            else if (ModelState.IsValid)
            {
                vehicleLicenceType.Status = AppConstant.Active;
                vehicleLicenceType.CompanyID = AppConstant.CompanyID;
                vehicleLicenceType.CreatedOn = DateTime.Now;
                vehicleLicenceType.ModifiedOn = DateTime.Now;
                vehicleLicenceType.IP = GetIPAddress.getExternalIp();
                _context.Add(vehicleLicenceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleLicenceType);
        }


        // GET: VehicleLicenceTypes/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_context.vehicleLicenceType.Find(id));
        }

        // POST: VehicleLicenceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("VehLicTypeId,VehLicTypeName,VehLicTypeCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehicleLicenceType vehicleLicenceType)
        {
            if (ModelState.IsValid)
            {

                vehicleLicenceType.ModifiedOn = DateTime.Now;
                vehicleLicenceType.IP = GetIPAddress.getExternalIp();
                _context.Update(vehicleLicenceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleLicenceType);
        }

        
        // Get: VehicleLicenceTypes/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            var vehicleLicenceType = await _context.vehicleLicenceType.FindAsync(id);
            _context.vehicleLicenceType.Remove(vehicleLicenceType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
