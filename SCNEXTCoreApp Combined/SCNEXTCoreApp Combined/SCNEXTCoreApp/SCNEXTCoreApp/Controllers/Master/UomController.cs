using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCNEXTCoreApp.Data.Master;
using Microsoft.AspNetCore.Mvc;
using SCNEXTCoreApp.Models.Master;
using SCNEXTCoreApp.Data.Constant;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Text.RegularExpressions;
using SCNEXTCoreApp.Models;
using SCNEXTCoreApp.Models.ViewModel;
using PagedList.Core.Mvc;
using PagedList.Core;

namespace SCNEXTCoreApp.Controllers.Master
{
    public class UomController : Controller
    {
        private readonly GeneralDbContext context;
        public IPModel ipmodel = new IPModel();
        public UomController(GeneralDbContext context)
        {
            this.context = context;
        }   

        // GET: Uom/Create
        public ActionResult Index(string searchBy, string searching,int? page)

        {
            if (searchBy == "Name")
            {
                return View(context.Uom.Where(x => x.Name.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(context.Uom.Where(x => x.Code.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));

            }

        }
        // GET: Uom/Create
        [HttpGet]
        public IActionResult AddorEdit(int id = 0)
        {
            int Max = 0;
            if (id == 0)
            {
                Max = context.Uom.Select(p => p.UomId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.uom = "uom" + nextmax.ToString();
                return View(new Uom());
            }
            else
                return View(context.Uom.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("UomId,Name,Code,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Uom uom)
        {
           
            if (ModelState.IsValid)
            {
                if (uom.UomId == 0)
                {
                    uom.Status = AppConstant.Active;
                    // department.CreatedBy = userId;
                    uom.CreatedOn = System.DateTime.Now;
                    uom.ModifiedOn = System.DateTime.Now;
                    uom.IP = ipmodel.GetIp();
                    uom.CompanyID = AppConstant.CompanyID;
                    context.Add(uom);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));


                }
                else
                {
                    uom.Status = AppConstant.Active;
                    uom.ModifiedOn = System.DateTime.Now;
                    uom.IP = ipmodel.GetIp();
                    uom.CompanyID = AppConstant.CompanyID;
                    context.Update(uom);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(uom);
        }
        // GET: UOM/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var uom = await context.Uom.FindAsync(id);
            context.Uom.Remove(uom);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
        private bool UomExists(int id)
        {
            return context.Uom.Any(e => e.UomId == id);
        }
    }
}
