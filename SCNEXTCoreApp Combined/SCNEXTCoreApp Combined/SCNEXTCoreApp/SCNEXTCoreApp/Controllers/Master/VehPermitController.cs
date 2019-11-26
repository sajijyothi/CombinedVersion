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
using SCNEXTCoreApp.Models.ViewModel;
using PagedList.Core.Mvc;
using PagedList.Core;

namespace SCNEXTCoreApp.Controllers.Master
{
    public class VehPermitController : Controller
    {
        private readonly GeneralDbContext context;
       // private readonly AppConstant Appcontext;
        IPModel GETIP = new IPModel();

        public VehPermitController(GeneralDbContext context)
        {
            this.context = context;
        }

        // GET: VehPermit
        public IActionResult Index(string searchBy, string searching, int? page)
        {

            if (searchBy == "Name")
            {
                return View(context.VehPermit.Where(x => x.VehPermitName.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(context.VehPermit.Where(x => x.Code.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }

        }


        // GET: VehPermit/Create
        public IActionResult AddorEdit(int id = 0)
        {
            int Max = 0;
            if (id == 0)
            {
                Max = context.VehPermit.Select(p => p.VehPermitId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.vehper = "vhpr" + nextmax.ToString();
                return View(new VehPermit());
            }
            else
                return View(context.VehPermit.Find(id));
        }

        // POST: VehPermit/Create
          [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("VehPermitId,VehPermitName,Code,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehPermit vehPermit)
        {
            if (ModelState.IsValid)
            {
                if (vehPermit.VehPermitId == 0)
                {
                    vehPermit.Status = AppConstant.Active;
                    vehPermit.CreatedOn = System.DateTime.Now;
                    vehPermit.ModifiedOn = System.DateTime.Now;
                    vehPermit.IP = GETIP.GetIp();
                    vehPermit.CompanyID = AppConstant.CompanyID;
                    context.Add(vehPermit);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));


                }
                else
                {
                    vehPermit.Status = AppConstant.Active;
                    vehPermit.ModifiedOn = System.DateTime.Now;
                    vehPermit.IP = GETIP.GetIp();
                    vehPermit.CompanyID = AppConstant.CompanyID;
                    context.Update(vehPermit);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(vehPermit);
        }

        
        // GET: VehPermit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehpermit = await context.VehPermit.FindAsync(id);
            context.VehPermit.Remove(vehpermit);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }

       
    }
}
