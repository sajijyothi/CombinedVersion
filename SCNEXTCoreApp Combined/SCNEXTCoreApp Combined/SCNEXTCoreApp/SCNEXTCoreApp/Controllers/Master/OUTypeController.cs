using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCNEXTCoreApp.Data.Master;
using SCNEXTCoreApp.Models.Master;
using PagedList.Core;
using SCNEXTCoreApp.Models.ViewModel;
using SCNEXTCoreApp.Data.Constant;

namespace SCNEXTCoreApp.Controllers
{
    public class OUTypeController : Controller
    {
        private readonly GeneralDbContext context;
        IPModel GETIP = new IPModel();

        public OUTypeController(GeneralDbContext context)
        {
            this.context = context;
        }

        // GET: OUType
        public IActionResult Index(string searchBy, string searching, int? page)
        {
            if (searchBy == "Name")
            {
                return View(context.OUType.Where(x => x.Name.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(context.OUType.Where(x => x.Code.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
        }
               
        // GET: OUType/Create
        public IActionResult AddorEdit(int id=0)
        {
            int Max = 0;
            if (id == 0)
            {
                Max = context.OUType.Select(p => p.OUTypeID).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.OUType = "OUT00" + nextmax.ToString();
                return View(new OUType());
            }
            else
                return View(context.OUType.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("OUTypeID,Name,Code,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] OUType oUType)
        {
            if (ModelState.IsValid)
            {
                if (oUType.OUTypeID == 0)
                {
                    oUType.Status = AppConstant.Active;
                    oUType.CreatedOn = System.DateTime.Now;
                    oUType.ModifiedOn = System.DateTime.Now;
                    oUType.IP = GETIP.GetIp();
                    oUType.CompanyID = AppConstant.CompanyID;
                    context.Add(oUType);
                }
                else
                {
                    oUType.Status = AppConstant.Active;
                    oUType.ModifiedOn = System.DateTime.Now;
                    oUType.IP = GETIP.GetIp();
                    oUType.CompanyID = AppConstant.CompanyID;
                    context.Update(oUType);
                }
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oUType);
        }


        // GET: OUType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var oUType = await context.OUType.FindAsync(id);
            context.OUType.Remove(oUType);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
