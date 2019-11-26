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
using PagedList.Core.Mvc;
using PagedList.Core;

namespace SCNEXTCoreApp.Controllers.Master
{
    public class CountryController : Controller
    {
        private readonly GeneralDbContext _context;

        public CountryController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: Country
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.country.ToListAsync());
        //}

        public IActionResult Index(string searchBy, string search,int? page)
        {
            if (searchBy == "CountryName")
                return View(_context.country.Where(m => m.CountryName == search || search == null)
                    .ToPagedList(page ?? 1, 3));
            else
                return View(_context.country.Where(m => m.CountryCode == search || search == null)
                    .ToPagedList(page ??1, 3));
        }

        // GET: Country/Create
        public IActionResult Create()
        {            
            return View(new Country());
        }

        // POST: Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryId,CountryName,CountryCode,callingCode,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Country country)
        {
            if (_context.country.Any(m => m.CountryCode.Equals(country.CountryCode)))
            {
                ModelState.AddModelError("", "[" + country.CountryCode + "]already exists");
            }
            else if (ModelState.IsValid)
            {
                country.Status = AppConstant.Active;
                country.CompanyID = AppConstant.CompanyID;
                country.CreatedOn = DateTime.Now;
                country.ModifiedOn = DateTime.Now;
                country.IP = GetIPAddress.getExternalIp();
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Country/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_context.country.Find(id));
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CountryId,CountryName,CountryCode,callingCode,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Country country)
        {
            if (ModelState.IsValid)
            {

                country.ModifiedOn = DateTime.Now;
                country.IP = GetIPAddress.getExternalIp();
                _context.Update(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(country);
        }


        // GET: Country/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var country = await _context.country.FindAsync(id);
            _context.country.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
