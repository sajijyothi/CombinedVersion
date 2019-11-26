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
using SCNEXTCoreApp.Models.ViewModel;
using PagedList.Core.Mvc;
using PagedList.Core;


namespace SCNEXTCoreApp.Controllers.Master
{
    public class vehownerController : Controller
    {
        private readonly GeneralDbContext context;
       // private readonly AppConstant Appcontext;
        IPModel GETIP = new IPModel();

        public vehownerController(GeneralDbContext context)
        {
            this.context = context;
        }

        // GET: vehowner
        public ActionResult Index(string searchBy, string searching,int? page)    
        {
            if (searchBy == "Name")
            {
                return View(context.vehowner.Where(x => x.Name.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(context.vehowner.Where(x => x.Code.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));

            }

        }
        // GET: vehowner/Create
        public IActionResult AddorEdit(int id = 0)
        {
            int Max = 0;
            if (id == 0)
            {
                Max = context.vehowner.Select(p => p.VehOwnerId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.vehowner = "vehown" + nextmax.ToString();
                return View(new vehowner());
            }
            else
                return View(context.vehowner.Find(id));
        }
      [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("VehOwnerId,Name,Code,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] vehowner vehowner)
        {
            if (ModelState.IsValid)
            {
                if (vehowner.VehOwnerId == 0)
                {
                    vehowner.Status = AppConstant.Active;
                    vehowner.CreatedOn = System.DateTime.Now;
                    vehowner.ModifiedOn = System.DateTime.Now;
                    vehowner.IP = GETIP.GetIp();
                    vehowner.CompanyID = AppConstant.CompanyID;
                    context.Add(vehowner);
                }
                else
                {
                    vehowner.Status = AppConstant.Active;
                    vehowner.ModifiedOn = System.DateTime.Now;
                    vehowner.IP = GETIP.GetIp();
                    vehowner.CompanyID = AppConstant.CompanyID;
                    context.Update(vehowner);
                }
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehowner);
        }


        // GET: vehowner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehowner = await context.vehowner.FindAsync(id);
            context.vehowner.Remove(vehowner);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        private bool vehownerExists(int id)
        {
            return context.vehowner.Any(e => e.VehOwnerId == id);
        }
    }
}
