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
    public class EmpSkillSetController : Controller
    {
        private readonly GeneralDbContext _context;

        public EmpSkillSetController(GeneralDbContext context)
        {
            _context = context;
        }

        //// GET: EmpSkillSet
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.EmpSkillSet.ToListAsync());
        //}

        // GET: EmpSkillSet
        public IActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == "EmpSkillSetName")
                return View(_context.EmpSkillSet.Where(m => m.EmpSkillSetName == search || search == null).ToPagedList(page??1, 3));
            else
                return View(_context.EmpSkillSet.Where(m => m.EmpSkillSetCode == search || search == null).ToPagedList(page??1, 3));
        }

        

        // GET: EmpSkillSet/Create
        public IActionResult Create()
        {
            int max = 0;
            max = _context.EmpSkillSet.Select(e => e.EmpSkillSetId)
                    .DefaultIfEmpty().Max();

            int netmax = max + 1;
            ViewBag.Code = "Eskillset" + netmax.ToString();

            return View(new EmpSkillSet());
        }

        // POST: EmpSkillSet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpSkillSetId,EmpSkillSetName,EmpSkillSetCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] EmpSkillSet empSkillSet)
        {
            if (ModelState.IsValid)
            {
                empSkillSet.Status = AppConstant.Active;
                empSkillSet.CompanyID = AppConstant.CompanyID;
                empSkillSet.CreatedOn = DateTime.Now;
                empSkillSet.ModifiedOn = DateTime.Now;
                empSkillSet.IP = GetIPAddress.getExternalIp();
                _context.Add(empSkillSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empSkillSet);
        }

        // GET: EmpSkillSet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var empSkillSet = await _context.EmpSkillSet.FindAsync(id);
            return View(empSkillSet);
        }

        // POST: EmpSkillSet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("EmpSkillSetId,EmpSkillSetName,EmpSkillSetCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] EmpSkillSet empSkillSet)
        {
            if (ModelState.IsValid)
            {

                empSkillSet.ModifiedOn = DateTime.Now;
                empSkillSet.IP = GetIPAddress.getExternalIp();
                _context.Update(empSkillSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(empSkillSet);
        }

        // GET: EmpSkillSet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var empSkillSet = await _context.EmpSkillSet.FindAsync(id);
            _context.EmpSkillSet.Remove(empSkillSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
