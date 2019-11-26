using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCNEXTCoreApp.Data.Constant;
using SCNEXTCoreApp.Data.Master;
using SCNEXTCoreApp.Models;
using SCNEXTCoreApp.Models.Master;
using PagedList.Core.Mvc;
using PagedList.Core;


using SCNEXTCoreApp.Models.ViewModel;

namespace SCNEXTCoreApp.Controllers.Master
{
    public class taxmasterController : Controller
    {
        private readonly GeneralDbContext context;
       // private readonly AppConstant Appcontext;
        IPModel GETIP = new IPModel();
        public taxmasterController(GeneralDbContext context)
        {
            this.context = context;
        }

        // GET: taxmaster
        public IActionResult Index(string search, int? page)
        {
            return View(GetDetail(search, page));
        }
        public IEnumerable<taxmaster> GetDetail(string search, int? page)
        {
            var query = (from ct in context.taxmaster
                         
                         where ct.TaxName == search || ct.Code == search || search == null
                         select new taxmaster
                         {
                             TaxName = ct.TaxName,
                             Code = ct.Code,
                             Rate = (double)(ct.Rate)                       


                         }).Distinct().ToPagedList(page ?? 1, 3);
            return query;
        }

        // GET: taxmaster/Create
        public IActionResult AddorEdit(int id=0)
        {
           
            int Max = 0;
             if (id == 0)
            {
                Max = context.taxmaster.Select(p => p.TaxId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.taxmaster = "taxms" + nextmax.ToString();
               
                return View(new taxmaster());
            }
            else
                return View(context.taxmaster.Find(id));
        }

        // POST: taxmaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("TaxId,TaxName,Code,Rate,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] taxmaster taxmaster)
        {
            if (ModelState.IsValid)
            {
               if (taxmaster.TaxId == 0)
                {
                    taxmaster.Status = AppConstant.Active;
                    taxmaster.CreatedOn = System.DateTime.Now;
                    taxmaster.ModifiedOn = System.DateTime.Now;
                    taxmaster.IP = GETIP.GetIp();
                    
                    taxmaster.CompanyID = AppConstant.CompanyID;
                    context.Add(taxmaster);
                }
                else
                {
                    taxmaster.Status = AppConstant.Active;
                    taxmaster.ModifiedOn = System.DateTime.Now;
                    taxmaster.IP = GETIP.GetIp();
                    taxmaster.CompanyID = AppConstant.CompanyID;
                    context.Update(taxmaster);
                }
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxmaster);
        }

        
        // GET: taxmaster/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var taxmaster = await context.taxmaster.FindAsync(id);
            context.taxmaster.Remove(taxmaster);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

      
    }
}
