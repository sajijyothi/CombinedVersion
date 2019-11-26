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
using PagedList.Core.Mvc;
using PagedList.Core;
using SCNEXTCoreApp.Models.ViewModel;


namespace SCNEXTCoreApp.Controllers.Master
{
    public class VehicletypeController : Controller
    {

        public IPModel ipmodel = new IPModel();
        public string externalIP;      
        private readonly GeneralDbContext context;
     
        public VehicletypeController(GeneralDbContext context)
        {
            this.context = context;
        }
        public ActionResult Index(string searchBy, string searching, int? page)
        {
            if (searchBy == "Name")
            {
                return View(context.vehicletype.Where(x => x.Name.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(context.vehicletype.Where(x => x.Code.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));

            }

        }
        // GET: Vehicletype/Create
        [HttpGet]
        public IActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                int Max = 0;
                Max = context.vehicletype.Select(p => p.VehtypeId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.vehtype = "vhty" + nextmax.ToString();
                return View(new Vehicletype());
            }
            else
                return View(context.vehicletype.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("VehtypeId,Name,Code,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Vehicletype vehicletype)
        {
           
            if (ModelState.IsValid)
            {
                
                if (vehicletype.VehtypeId == 0)
                {
                    vehicletype.Status = AppConstant.Active;
                    vehicletype.CreatedOn = System.DateTime.Now;
                    vehicletype.ModifiedOn = System.DateTime.Now;
                    vehicletype.IP = ipmodel.GetIp();
                    vehicletype.CompanyID = AppConstant.CompanyID;
                    context.Add(vehicletype);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    vehicletype.Status = AppConstant.Active;
                    //uom.CreatedOn = System.DateTime.Now;
                    vehicletype.ModifiedOn = System.DateTime.Now;
                    vehicletype.IP = ipmodel.GetIp();
                    vehicletype.CompanyID = AppConstant.CompanyID;

                    context.Update(vehicletype);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
                return View(vehicletype);
        }
        // GET: Vehicletype/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicletype = await context.vehicletype.FindAsync(id);
            context.vehicletype.Remove(vehicletype);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}