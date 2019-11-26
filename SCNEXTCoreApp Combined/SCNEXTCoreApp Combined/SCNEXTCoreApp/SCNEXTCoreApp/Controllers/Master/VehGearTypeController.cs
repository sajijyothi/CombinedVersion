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
    public class VehGearTypeController : Controller
    {
        private readonly GeneralDbContext context;
        IPModel Ipadd = new IPModel();


        public VehGearTypeController(GeneralDbContext context)
        {
            this.context = context;
        }

        // GET: VehGearType
        public IActionResult Index(string searchBy, string searching, int? page)
        {

            if (searchBy == "Name")
            {
                return View(context.VehGearType.Where(x => x.VehGearTypeName.Contains(searching) || searching == null).ToPagedList(page ?? 1, 5));
            }
            else
            {
                return View(context.VehGearType.Where(x => x.VehGearTypeCode.Contains(searching) || searching == null).ToPagedList(page ?? 1, 5));
            }

        }
        // GET: VehGearType/Create
        public IActionResult AddorEdit(int id=0)
        {
            int Max = 0;
            if (id == 0)
            {
                Max = context.VehGearType.Select(p => p.VehGearTypeId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.vehgear = "Gear-0" + nextmax.ToString();
                return View(new VehGearType());
            }
            else
                return View(context.VehGearType.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("VehGearTypeId,VehGearTypeName,VehGearTypeCode,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] VehGearType vehGearType)
        {
            if (ModelState.IsValid)
            {
                if (vehGearType.VehGearTypeId == 0)
                {
                    vehGearType.Status = AppConstant.Active;
                    vehGearType.CreatedOn = System.DateTime.Now;
                    vehGearType.ModifiedOn = System.DateTime.Now;
                    vehGearType.IP = Ipadd.GetIp();
                    vehGearType.CompanyID = AppConstant.CompanyID;
                    context.Add(vehGearType);
                }
                else
                {
                    vehGearType.Status = AppConstant.Active;
                    vehGearType.ModifiedOn = System.DateTime.Now;
                    vehGearType.IP = Ipadd.GetIp();
                    vehGearType.CompanyID = AppConstant.CompanyID;
                    context.Update(vehGearType);
                }
                context.Add(vehGearType);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehGearType);
        }


        // GET: VehGearType/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehgeartype = await context.VehGearType.FindAsync(id);
            context.VehGearType.Remove(vehgeartype);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
