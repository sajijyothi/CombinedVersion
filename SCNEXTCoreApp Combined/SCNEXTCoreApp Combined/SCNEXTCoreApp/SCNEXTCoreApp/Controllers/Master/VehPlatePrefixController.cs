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
    public class VehPlatePrefixController : Controller
    {
        private readonly GeneralDbContext _context;

        public VehPlatePrefixController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: VehPlatePrefix
        public IActionResult Index(string searchBy, string search,int? page)
        {
            if (searchBy == "VehPlatePrefixName")
                return View(_context.VehPlatePrefix.Where(m => m.VehPlatePrefixName == search || search == null).ToPagedList(page??1, 3));
            else
                return View(_context.VehPlatePrefix.Where(m => m.VehPlatePrefixCode == search || search == null).ToPagedList(page??1, 3));
        }
                             

        // GET: VehPlatePrefix/Create
        public IActionResult Create()
        {
            return View(new VehPlatePrefix());
        }

        // POST: VehPlatePrefix/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehPlatePrefixId,VehPlatePrefixName,VehPlatePrefixCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehPlatePrefix vehPlatePrefix)
        {
            if (ModelState.IsValid)
            {
                vehPlatePrefix.Status = AppConstant.Active;
                vehPlatePrefix.CompanyID = AppConstant.CompanyID;
                vehPlatePrefix.CreatedOn = DateTime.Now;
                vehPlatePrefix.ModifiedOn = DateTime.Now;
                vehPlatePrefix.IP = GetIPAddress.getExternalIp();
                _context.Add(vehPlatePrefix);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehPlatePrefix);
        }

        // GET: VehPlatePrefix/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var vehPlatePrefix = await _context.VehPlatePrefix.FindAsync(id);
            return View(vehPlatePrefix);
        }

        // POST: VehPlatePrefix/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("VehPlatePrefixId,VehPlatePrefixName,VehPlatePrefixCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehPlatePrefix vehPlatePrefix)
        {
            if (ModelState.IsValid)
            {

                vehPlatePrefix.ModifiedOn = DateTime.Now;
                vehPlatePrefix.IP = GetIPAddress.getExternalIp();
                _context.Update(vehPlatePrefix);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(vehPlatePrefix);
        }        
       
        // GET: VehPlatePrefix/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var vehPlatePrefix = await _context.VehPlatePrefix.FindAsync(id);
            _context.VehPlatePrefix.Remove(vehPlatePrefix);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
