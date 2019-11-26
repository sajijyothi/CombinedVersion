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
    public class VehBrandController : Controller
    {
        private readonly GeneralDbContext _context;

        public VehBrandController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: VehBrand
        public IActionResult Index(string searchBy, string search,int? page)
        {
            if (searchBy == "VehBrandName")
                return View(_context.VehBrand.Where(m => m.VehBrandName == search || search == null).ToPagedList(page??1, 3));
            else
                return View(_context.VehBrand.Where(m => m.VehBrandCode == search || search == null).ToPagedList(page??1, 3));
        }



        // GET: VehBrand/Create
        public IActionResult Create()
        {
            return View(new VehBrand());
        }

        // POST: VehBrand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehBrandId,VehBrandName,VehBrandCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehBrand vehBrand)
        {
            if (ModelState.IsValid)
            {
                vehBrand.Status = AppConstant.Active;
                vehBrand.CompanyID = AppConstant.CompanyID;
                vehBrand.CreatedOn = DateTime.Now;
                vehBrand.ModifiedOn = DateTime.Now;
                vehBrand.IP = GetIPAddress.getExternalIp();
                _context.Add(vehBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehBrand);
        }

        // GET: VehBrand/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var vehBrand = await _context.VehBrand.FindAsync(id);
            return View(vehBrand);
        }

        // POST: VehBrand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("VehBrandId,VehBrandName,VehBrandCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehBrand vehBrand)
        {
            if (ModelState.IsValid)
            {

                vehBrand.ModifiedOn = DateTime.Now;
                vehBrand.IP = GetIPAddress.getExternalIp();
                _context.Update(vehBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(vehBrand);
        }

        

        // GET: VehBrand/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var vehBrand = await _context.VehBrand.FindAsync(id);
            _context.VehBrand.Remove(vehBrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
