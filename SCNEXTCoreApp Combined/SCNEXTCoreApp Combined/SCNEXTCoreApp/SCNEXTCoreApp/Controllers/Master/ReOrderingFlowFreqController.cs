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
    public class ReOrderingFlowFreqController : Controller
    {
        private readonly GeneralDbContext _context;

        public ReOrderingFlowFreqController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: ReOrderingFlowFreq
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.ReOrderingFlowFreq.ToListAsync());
        //}

        //public IActionResult Index(string searchBy, string search, int? page)
        //{
        //    if (searchBy == "Name")
        //        return View(_context.ReOrderingFlowFreq.Where(m => m.ReOrderingFlowFreqName == search || search == null)
        //            .ToPagedList(page ?? 1, 3));
        //    else
        //        return View(_context.ReOrderingFlowFreq.Where(m => m.ReOrderingFlowFreqName == search || search == null)
        //            .ToPagedList(page ?? 1, 3));
        //}

        //// GET: ReOrderingFlowFreq/Create
        //public IActionResult Create()
        //{
        //    return View(new ReOrderingFlowFreq());
        //}

        //// POST: ReOrderingFlowFreq/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ReOrderingFlowFreqId,ReOrderingFlowFreqName,ReOrderingFlowFreqCode,ReOrderingFlowFreqDescription,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] ReOrderingFlowFreq reOrderingFlowFreq)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        reOrderingFlowFreq.Status = AppConstant.Active;
        //        reOrderingFlowFreq.CompanyID = AppConstant.CompanyID;
        //        reOrderingFlowFreq.CreatedOn = DateTime.Now;
        //        reOrderingFlowFreq.ModifiedOn = DateTime.Now;
        //        reOrderingFlowFreq.IP = GetIPAddress.getExternalIp();
        //        _context.Add(reOrderingFlowFreq);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(reOrderingFlowFreq);
        //}

        //// GET: ReOrderingFlowFreq/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    var reOrderingFlowFreq = await _context.ReOrderingFlowFreq.FindAsync(id);
        //    return View(reOrderingFlowFreq);
        //}

        //// POST: ReOrderingFlowFreq/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit([Bind("ReOrderingFlowFreqId,ReOrderingFlowFreqName,ReOrderingFlowFreqCode,ReOrderingFlowFreqDescription,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] ReOrderingFlowFreq reOrderingFlowFreq)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        reOrderingFlowFreq.ModifiedOn = DateTime.Now;
        //        reOrderingFlowFreq.IP = GetIPAddress.getExternalIp();
        //        _context.Update(reOrderingFlowFreq);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(reOrderingFlowFreq);
        //}

       
        //// POST: ReOrderingFlowFreq/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    var reOrderingFlowFreq = await _context.ReOrderingFlowFreq.FindAsync(id);
        //    _context.ReOrderingFlowFreq.Remove(reOrderingFlowFreq);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}       
    }
}
