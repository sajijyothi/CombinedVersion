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
    public class StateController : Controller
    {
        private readonly GeneralDbContext _context;

        public StateController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: State
        public IActionResult Index(string search,int? page)
        {           
            return View(GetDetail(search,page));
        }

       
        public IEnumerable<State> GetDetail(string search,int? page)
        {
            var query = (from s in _context.state
                         join c in _context.country on s.CountryId equals c.CountryId
                         where s.StateName==search|| search ==null ||s.StateCode== search

                         select new State
                         {
                              StateId   = s.StateId,
                              StateName = s.StateName,
                              StateCode = s.StateCode,
                              CountryName=c.CountryName,
                         }).Distinct().ToPagedList(page??1, 3);
            return query;
        }

        // GET: State/Create
        public IActionResult Create()
        {
            ViewBag.Country = new SelectList(_context.country, "CountryId", "CountryName");
            return View(new State());
        }


        // POST: State/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateId,StateName,StateCode,CountryId,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] State state)
        {
            //if(_context.state.Any(e=>e.StateCode.Equals(state.StateCode)))
            //{
            //    ModelState.AddModelError("", "["+state.StateCode+"] already exist");

            //}
            //else 
            if (ModelState.IsValid)
            {
                
                state.Status = AppConstant.Active;
                state.CompanyID = AppConstant.CompanyID;
                state.CreatedOn = System.DateTime.Now;
                state.ModifiedOn = System.DateTime.Now;
                state.IP = GetIPAddress.getExternalIp();
                _context.Add(state);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }


        // GET: State/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Country = new SelectList(_context.country, "CountryId", "CountryName");
            //return View(_context.state.Find(id));
            var state = await _context.state.FindAsync(id);
            return View(state);
        }


        // POST: State/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("StateId,StateName,StateCode,CountryId,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] State state)
        {
            
            if (ModelState.IsValid)
            {
                state.ModifiedOn = DateTime.Now;
                state.IP = GetIPAddress.getExternalIp();
                _context.Update(state);
                await _context.SaveChangesAsync();                
                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }


        // GET: State/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var state = await _context.state.FindAsync(id);
            _context.state.Remove(state);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }        
    }
}
