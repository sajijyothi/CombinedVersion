using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class DgClassDangerousController : Controller
    {
        private readonly GeneralDbContext _context;

        public DgClassDangerousController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: DgClassDangerous
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.DgClassDangerous.ToListAsync());
        //}

        public IActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == "Name")
                return View(_context.DgClassDangerous.Where(m => m.DgClassDangerousName == search || search == null)
                    .ToPagedList(page ?? 1, 3));
            else
                return View(_context.DgClassDangerous.Where(m => m.DgClassDangerousName == search || search == null)
                    .ToPagedList(page ?? 1, 3));
        }

        // GET: DgClassDangerous/Create
        public IActionResult Create()
        {
            return View(new DgClassDangerous());
        }

        // POST: DgClassDangerous/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DgClassDangerousId,DgClassDangerousName,DgClassDangerousCode,DgClassDangerousDescription,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] DgClassDangerous dgClassDangerous)
        {
            if (ModelState.IsValid)
            {
                dgClassDangerous.Status = AppConstant.Active;
                dgClassDangerous.CompanyID = AppConstant.CompanyID;
                dgClassDangerous.CreatedOn = DateTime.Now;
                dgClassDangerous.ModifiedOn = DateTime.Now;
                dgClassDangerous.IP = GetIPAddress.getExternalIp();
                _context.Add(dgClassDangerous);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dgClassDangerous);
        }

        // GET: DgClassDangerous/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dgClassDangerous = await _context.DgClassDangerous.FindAsync(id);
            return View(dgClassDangerous);
        }

        // POST: DgClassDangerous/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("DgClassDangerousId,DgClassDangerousName,DgClassDangerousCode,DgClassDangerousDescription,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] DgClassDangerous dgClassDangerous)
        {
           if (ModelState.IsValid)
            {
                dgClassDangerous.ModifiedOn = DateTime.Now;
                dgClassDangerous.IP = GetIPAddress.getExternalIp();
                _context.Update(dgClassDangerous);
                await _context.SaveChangesAsync();                
                return RedirectToAction(nameof(Index));
            }
            return View(dgClassDangerous);
        }

        // POST: DgClassDangerous/Delete/5
       public async Task<IActionResult> Delete(int? id)
        {
            var dgClassDangerous = await _context.DgClassDangerous.FindAsync(id);
            _context.DgClassDangerous.Remove(dgClassDangerous);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
