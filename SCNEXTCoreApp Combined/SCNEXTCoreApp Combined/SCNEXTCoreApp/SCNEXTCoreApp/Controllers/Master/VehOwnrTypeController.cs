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
    public class VehOwnrTypeController : Controller
    {
        private readonly GeneralDbContext _context;

        public VehOwnrTypeController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: VehOwnrType
        public IActionResult Index(string searchBy, string search,int? page)
        {
            if (searchBy == "VehOwnrTypeName")
                return View(_context.VehOwnrType.Where(m => m.VehOwnrTypeName == search || search == null).ToPagedList(page??1, 3));
            else
                return View(_context.VehOwnrType.Where(m => m.VehOwnrTypeCode == search || search == null).ToPagedList(page??1, 3));
        }


        
        // GET: VehOwnrType/Create
        public IActionResult Create()
        {
            return View(new VehOwnrType());
        }

        // POST: VehOwnrType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehOwnrTypeId,VehOwnrTypeName,VehOwnrTypeCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehOwnrType vehOwnrType)
        {
            if (ModelState.IsValid)
            {
                vehOwnrType.Status = AppConstant.Active;
                vehOwnrType.CompanyID = AppConstant.CompanyID;
                vehOwnrType.CreatedOn = DateTime.Now;
                vehOwnrType.ModifiedOn = DateTime.Now;
                vehOwnrType.IP = GetIPAddress.getExternalIp();
                _context.Add(vehOwnrType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehOwnrType);
        }

        // GET: VehOwnrType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var vehOwnrType = await _context.VehOwnrType.FindAsync(id);
            return View(vehOwnrType);
        }

        // POST: VehOwnrType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("VehOwnrTypeId,VehOwnrTypeName,VehOwnrTypeCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehOwnrType vehOwnrType)
        {
            if (ModelState.IsValid)
            {

                vehOwnrType.ModifiedOn = DateTime.Now;
                vehOwnrType.IP = GetIPAddress.getExternalIp();
                _context.Update(vehOwnrType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(vehOwnrType);
        }
           

        // GET: VehOwnrType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var vehOwnrType = await _context.VehOwnrType.FindAsync(id);
            _context.VehOwnrType.Remove(vehOwnrType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
