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
    public class HSCodeController : Controller
    {
        private readonly GeneralDbContext context;
        IPModel Ipadd = new IPModel();

        public HSCodeController(GeneralDbContext context)
        {
            this.context = context;
        }

        // GET: HSCode
        public IActionResult Index(string searchBy, string searching, int? page)
        {

            if (searchBy == "Name")
            {
                return View(context.HSCode.Where(x => x.Name.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(context.HSCode.Where(x => x.Code.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }

        }

        

        // GET: HSCode/Create
        public IActionResult AddorEdit(int id=0)
        {
            int Max = 0;
            if (id == 0)
            {
                Max = context.HSCode.Select(p => p.HSCodeId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.HSCode = "HS000" + nextmax.ToString();
                return View(new HSCode());
            }
            else
                return View(context.currency.Find(id));
        }

           [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("HSCodeId,Name,Code,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] HSCode hSCode)
        {
            if (ModelState.IsValid)
            {
                if (hSCode.HSCodeId == 0)
                {
                    hSCode.Status = AppConstant.Active;
                    hSCode.CreatedOn = System.DateTime.Now;
                    hSCode.ModifiedOn = System.DateTime.Now;
                    hSCode.IP = Ipadd.GetIp();
                    hSCode.CompanyID = AppConstant.CompanyID;
                    context.Add(hSCode); 
                }
                else
                {
                    hSCode.Status = AppConstant.Active;
                    hSCode.ModifiedOn = System.DateTime.Now;
                    hSCode.IP = Ipadd.GetIp();
                    hSCode.CompanyID = AppConstant.CompanyID;
                     context.Update(hSCode);
                }
                
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hSCode);
        }



        // GET: HSCode/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var HSCode = await context.HSCode.FindAsync(id);
            context.HSCode.Remove(HSCode);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
