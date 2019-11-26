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
    public class JobStatusController : Controller
    {
        private readonly GeneralDbContext _context;

        public JobStatusController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: JobStatus
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.jobStatus.ToListAsync());
        //}
        public IActionResult Index(string searchBy, string search,int? page)
        {
            if (searchBy == "JobStatName")
                return View(_context.jobStatus.Where(m => m.JobStatName == search || search == null).ToPagedList(page?? 1, 3));
            else
                return View(_context.jobStatus.Where(m => m.JobStatCode == search || search == null).ToPagedList(page?? 1, 3));

        }

        // GET: JobStatus/Create
        public IActionResult Create()
        {
            return View(new JobStatus());
        }

        // POST: JobStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobStatId,JobStatName,JobStatCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] JobStatus jobStatus)
        {
            if (_context.jobStatus.Any(m => m.JobStatCode.Equals(jobStatus.JobStatCode)))
            {
                ModelState.AddModelError("", "[" + jobStatus.JobStatCode + "]already exists");
            }

            else if (ModelState.IsValid)
            {
                jobStatus.Status = AppConstant.Active;
                jobStatus.CompanyID = AppConstant.CompanyID;
                jobStatus.CreatedOn = DateTime.Now;
                jobStatus.ModifiedOn = DateTime.Now;
                jobStatus.IP = GetIPAddress.getExternalIp();
                _context.Add(jobStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobStatus);
        }

        // GET: JobStatus/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_context.jobStatus.Find(id));
        }

        // POST: JobStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("JobStatId,JobStatName,JobStatCode,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] JobStatus jobStatus)
        {
            //if (_context.jobStatus.Any(m => m.Code.Equals(jobStatus.Code)))
            //{
            //    ModelState.AddModelError("", "[" + jobStatus.Code + "]already exists");
            //}

            if (ModelState.IsValid)
            {

                jobStatus.ModifiedOn = DateTime.Now;
                jobStatus.IP = GetIPAddress.getExternalIp();
                _context.Update(jobStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobStatus);
        }

        
        // GET: JobStatus/Delete/5
                
        public async Task<IActionResult> Delete(int? id)
        {
            var jobStatus = await _context.jobStatus.FindAsync(id);
            _context.jobStatus.Remove(jobStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }       
    }
}
