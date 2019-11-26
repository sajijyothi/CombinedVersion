using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public class CurrencyController : Controller
    {
        private readonly GeneralDbContext context;
        IPModel Ipadd = new IPModel();
     
        public CurrencyController(GeneralDbContext context)

        {
            this.context = context;
        }
        
        public IActionResult Index(string searchBy, string searching, int? page)
        {
         
            if (searchBy == "Name")
            {
                return View(context.currency.Where(x => x.Name.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(context.currency.Where(x => x.Code.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }

        }

        // GET: currency/Create
        [HttpGet]
        public IActionResult AddorEdit(int id = 0)
        {          
            int Max = 0;
            if (id == 0)
            {
                Max = context.currency.Select(p => p.CurrencyId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.currency = "Curr" + nextmax.ToString();
                return View(new Currency());
            }
            else
                return View(context.currency.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("CurrencyId,Name,Code,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                   
              if (currency.CurrencyId == 0)
                {
                    currency.Status = AppConstant.Active;
                    currency.CreatedOn = System.DateTime.Now;
                    currency.ModifiedOn = System.DateTime.Now;
                    currency.IP = Ipadd.GetIp();
                    currency.CompanyID = AppConstant.CompanyID;
                    context.Add(currency);
                }
                else
                {
                    currency.Status = AppConstant.Active;
                    currency.ModifiedOn = System.DateTime.Now;
                    currency.IP = Ipadd.GetIp();
                    currency.CompanyID = AppConstant.CompanyID;
                    // context.Entry(currency).State = EntityState.Modified;
                    context.Update(currency);
                }
                        await context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));                    

         }
            
            return View(currency);
        }
        

        // GET: currency/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Currency = await context.currency.FindAsync(id);
            context.currency.Remove(Currency);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        public JsonResult CheckCode(string Code)
        {
            Currency entities = new Currency();
            bool isValid = !entities.Code.Equals(Code, StringComparison.CurrentCultureIgnoreCase);
            return Json(isValid);
        }
    }
}
    