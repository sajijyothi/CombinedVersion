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
    public class CityController : Controller
    {
        private readonly GeneralDbContext _context;

        public CityController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: City
        public IActionResult Index(string search,int?page)
        {
            return View(GetDetail(search,page));
        }

        
        public IEnumerable<City> GetDetail(string search,int?page)
        {
            var query = (from ct in _context.city
                         join c in _context.country on ct.CountryId equals c.CountryId
                         join s in  _context.state on  ct.StateId equals s.StateId
                         where ct.CityName==search||search==null||ct.CityCode==search
                         select new City
                         {
                             CityId = ct.CityId,
                             CityName=ct.CityName,
                             CityCode=ct.CityCode,
                             StateName = s.StateName,
                             CountryName = c.CountryName,
                         }).Distinct().ToPagedList(page??1, 3);
            return query;
        }


        // GET: City/Create
        public IActionResult Create()
        {
            ViewBag.Country = new SelectList(_context.country, "CountryId", "CountryName");
            return View(new City());
        }

        // POST: City/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName,CityCode,CountryId,StateId,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] City city)
        {

            if (_context.city.Any(m => m.CityCode.Equals(city.CityCode)))
            {
                ModelState.AddModelError("", "[" + city.CityCode + "]already exists");
            }

            else if (ModelState.IsValid)
            {
                city.Status = AppConstant.Active;
                city.CompanyID = AppConstant.CompanyID;
                city.CreatedOn = DateTime.Now;
                city.ModifiedOn = DateTime.Now;
                city.IP = GetIPAddress.getExternalIp();            
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: City/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Country = new SelectList(_context.country, "CountryId", "CountryName");
            var city = await _context.city.FindAsync(id);
            return View(city);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CityId,CityName,CityCode,CountryId,StateId,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] City city)
        {
            if (ModelState.IsValid)
            {
                    city.ModifiedOn = DateTime.Now;
                    city.IP = GetIPAddress.getExternalIp();
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        

        // GET: City/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            var city = await _context.city.FindAsync(id);
            _context.city.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetState(int CountryId)
        {
            List<State> StateList = new List<State>();
            StateList = (from s in _context.state
                         where s.CountryId == CountryId
                         select s).ToList();
            StateList.Insert(0,new State { StateId=0, StateName="Select Any" });
            return Json(new SelectList(StateList, "StateId", "StateName"));
        }
                
    }
}
