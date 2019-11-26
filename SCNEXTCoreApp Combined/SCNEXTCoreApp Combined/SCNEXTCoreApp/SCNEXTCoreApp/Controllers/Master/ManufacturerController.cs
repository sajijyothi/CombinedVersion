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
using SCNEXTCoreApp.Models.ViewModel;
using static SCNEXTCoreApp.Models.ViewModel.UserDetails;
using PagedList.Core;

namespace SCNEXTCoreApp.Controllers.Master
{
    public class ManufacturerController : Controller
    {
        private readonly GeneralDbContext _context;

        public ManufacturerController(GeneralDbContext context)
        {
            _context = context;
        }

        ////GET: Manufacturer
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.manufacturer.ToListAsync());
        //}
        
        public IActionResult Index(string searchBy, string search,int? page)
        {
            if (searchBy == "MfrName")
                return View(_context.manufacturer.Where(m => m.MfrName == search || search == null).ToPagedList(page??1, 3));
            else
                return View(_context.manufacturer.Where(m => m.MfrCode == search || search == null).ToPagedList(page??1, 3));
        }


        // GET: Manufacturer/Create
        public IActionResult Create()
        {
            return View(new Manufacturer());
        }

        // POST: Manufacturer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MfrId,MfrName,MfrCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Manufacturer manufacturer)
        {
            if(_context.manufacturer.Any(m=>m.MfrCode.Equals(manufacturer.MfrCode)))
            {
                ModelState.AddModelError("", "[" + manufacturer.MfrCode + "]already exists");
            }

            else if (ModelState.IsValid)
            {
                manufacturer.Status = AppConstant.Active;
                manufacturer.CompanyID = AppConstant.CompanyID;
                manufacturer.CreatedOn = DateTime.Now;
                manufacturer.ModifiedOn = DateTime.Now;
                manufacturer.IP = GetIPAddress.getExternalIp();
                _context.Add(manufacturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }


        // GET: Manufacturer/Edit/5
        public IActionResult Edit(int id)
        {            
            return View(_context.manufacturer.Find(id));
        }

        // POST: Manufacturer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("MfrId,MfrName,MfrCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Manufacturer manufacturer)
        {
            //var users = (from m in _context.manufacturer
            //             where m.MfrCode == manufacturer.MfrCode
            //            select m).ToList();

            if (ModelState.IsValid)
            {
                
                manufacturer.ModifiedOn = DateTime.Now;
                    manufacturer.IP = GetIPAddress.getExternalIp();
                    _context.Update(manufacturer);
                    await _context.SaveChangesAsync();               
                 return RedirectToAction(nameof(Index));
                
            }
            return View(manufacturer);
        }

        
        // GET: Manufacturer/Delete/5         
        public async Task<IActionResult> Delete(int? id)
        {
            var manufacturer = await _context.manufacturer.FindAsync(id);
            _context.manufacturer.Remove(manufacturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
