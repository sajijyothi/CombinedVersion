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
    public class binareaController : Controller
    {
        private readonly GeneralDbContext context;
        IPModel GETIP = new IPModel();
        public binareaController(GeneralDbContext context)
        {
            this.context = context;
        }

        // GET: binarea
        public IActionResult Index(string searchBy, int? page)
        {
            return View(GetDetail(searchBy, page));
        }
        public IEnumerable<binarea> GetDetail(string search, int? page)
        {
            var query = (from u in context.Warehouse
                         join ct in context.binarea on u.WarehouseId equals ct.WarehouseId
                         where ct.BinName == search || ct.Code == search || search == null
                         select new binarea
                         {
                             BinName = ct.BinName,
                             Code = ct.Code,
                             WarehouseName = u.Name

                         }).Distinct().ToPagedList(page ?? 1, 3);
            return query;
        }


        // GET: binarea/Create
        public IActionResult AddorEdit(int id=0)
        {
            ViewData["WarehouseId"] = new SelectList(context.Warehouse, "WarehouseId", "Name");
            int Max = 0;
            if (id == 0)
            {
                Max = context.binarea.Select(p => p.binId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.Binarea = "Bin00" + nextmax.ToString();
                return View(new binarea());
            }
            else
                return View(context.binarea.Find(id));
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("binId,BinName,WarehouseId,Code,Remarks,IsAc,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] binarea binarea)
        {
            if (ModelState.IsValid)
            {
                if (binarea.binId == 0)
                {
                    binarea.Status = AppConstant.Active;
                    binarea.CreatedOn = System.DateTime.Now;
                    binarea.ModifiedOn = System.DateTime.Now;
                    binarea.IP = GETIP.GetIp();
                    binarea.CompanyID = AppConstant.CompanyID;
                    context.Add(binarea);
                }
                else
                {
                    binarea.Status = AppConstant.Active;
                    binarea.ModifiedOn = System.DateTime.Now;
                    binarea.IP = GETIP.GetIp();
                    binarea.CompanyID = AppConstant.CompanyID;
                    context.Update(binarea);
                }
                
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WarehouseId"] = new SelectList(context.Warehouse, "WarehouseId", "Name", binarea.WarehouseId);
            return View(binarea);
        }



        // GET: binarea/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var binarea = await context.binarea.FindAsync(id);
            context.binarea.Remove(binarea);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
