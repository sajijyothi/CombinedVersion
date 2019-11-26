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
using PagedList;
using PagedList.Core;


namespace SCNEXTCoreApp.Controllers.Master
{
    public class BrandController : Controller
    {
        private readonly GeneralDbContext _context; 

        public BrandController(GeneralDbContext context)
        {
            _context = context;
        }

        //GET: Brand
        public IActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == "BrandName")
                return View(_context.brand.Where(m => m.BrandName == search || search == null)
                    .ToPagedList(page ?? 1, 3));
            else
                return View(_context.brand.Where(m => m.BrandCode == search || search == null)
                    .ToPagedList(page ?? 1, 3));
        }

        // GET: BrandController
        //public IActionResult Index(string search, int? page)
        //{
        //    return View(GetDetail(search, page));
        //}

        //public IEnumerable<Brand> GetDetail(string search, int? page)
        //{
        //    var query = (from b in _context.brand
        //                 join m in _context.manufacturer on b.MfrId equals m.MfrId
        //                 where b.BrandName == search || search == null || b.BrandCode == search
        //                 select new Brand

        //                 {
        //                     BrandId = b.BrandId,
        //                     BrandName = b.BrandName,
        //                     BrandCode = b.BrandCode,
        //                     Description = b.Description,
        //                     MfrName = m.MfrName,
        //                 }).Distinct().ToPagedList(page ?? 1, 3);
        //    return query;
        //}


        // GET: Brand/Create
        public IActionResult Create()
        {
            int max = 0;
            max = _context.brand.Select(c => c.BrandId)
                        .DefaultIfEmpty().Max();

            int nextmax = max + 1;
            ViewBag.Code = "BR" + nextmax.ToString();
            ViewBag.Manufacturer = new SelectList(_context.manufacturer, "MfrId", "MfrName");
                        return View(new Brand());
        }

        // POST: Brand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,BrandName,BrandCode,Description,Status,MfrId,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                brand.Status = AppConstant.Active;
                brand.CompanyID = AppConstant.CompanyID;
                brand.CreatedOn = DateTime.Now;
                brand.ModifiedOn = DateTime.Now;
                brand.IP = GetIPAddress.getExternalIp();
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brand/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Manufacturer = new SelectList(_context.manufacturer, "MfrId", "MfrName");
            //            return View(_context.brand.Find(id));

            var brand = await _context.brand.FindAsync(id);            
            return View(brand);
        }

        // POST: Brand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("BrandId,BrandName,BrandCode,Description,Status,MfrId,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Brand brand)
        {

            if (ModelState.IsValid)
            {
                brand.ModifiedOn = DateTime.Now;
                brand.IP = GetIPAddress.getExternalIp();
                _context.Update(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }


       // GET: BrandController/Delete/5               
        public async Task<IActionResult> Delete(int? id)
        {
            var brand = await _context.brand.FindAsync(id);
            _context.brand.Remove(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
