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
    public class VehMakeController : Controller
    {
        private readonly GeneralDbContext _context;

        public VehMakeController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: VehMake
        public IActionResult Index(string searchBy, string search,int? page)
        {
            if (searchBy == "VehMakeName")
                return View(_context.VehMake.Where(m => m.VehMakeName == search || search == null).ToPagedList(page??1, 3));
            else
                return View(_context.VehMake.Where(m => m.VehMakeCode == search || search == null).ToPagedList(page??1, 3));
        }



        // GET: VehMake/Create
        public IActionResult Create()
        {
            return View(new VehMake());
        }

        // POST: VehMake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehMakeId,VehMakeName,VehMakeCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehMake vehMake)
        {
            if (ModelState.IsValid)
            {
                vehMake.Status = AppConstant.Active;
                vehMake.CompanyID = AppConstant.CompanyID;
                vehMake.CreatedOn = DateTime.Now;
                vehMake.ModifiedOn = DateTime.Now;
                vehMake.IP = GetIPAddress.getExternalIp();
                _context.Add(vehMake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehMake);
        }

        // GET: VehMake/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var vehMake = await _context.VehMake.FindAsync(id);
            return View(vehMake);
        }

        // POST: VehMake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("VehMakeId,VehMakeName,VehMakeCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehMake vehMake)
        {
            if (ModelState.IsValid)
            {

                vehMake.ModifiedOn = DateTime.Now;
                vehMake.IP = GetIPAddress.getExternalIp();
                _context.Update(vehMake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(vehMake);
        }

        
        // GET: VehMake/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var vehMake = await _context.VehMake.FindAsync(id);
            _context.VehMake.Remove(vehMake);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
