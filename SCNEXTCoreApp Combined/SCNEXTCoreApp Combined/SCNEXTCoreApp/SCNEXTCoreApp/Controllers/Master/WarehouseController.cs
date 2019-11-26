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
    public class WarehouseController : Controller
    {
        private readonly GeneralDbContext context;
        IPModel GETIP = new IPModel();


        public WarehouseController(GeneralDbContext context)
        {
            this.context = context;
        }

        // GET: Warehouse
       
            public IActionResult Index(string search,int? page)
            {
                 return View(GetDetail(search, page));

              }
        public IEnumerable<Warehouse> GetDetail(string search, int? page)
        {
            var query = (from ct in context.Warehouse
                         join cty in context.city on ct.CityId equals cty.CityId
                         join c in context.country on ct.CountryId equals c.CountryId
                         join s in context.state on ct.StateId equals s.StateId
                         join cr in context.currency on ct.WMCurrencyId equals cr.CurrencyId
                         join dt in context.department on ct.WMDepartmentId equals dt.DeptId
                         where ct.Name == search || search == null || ct.Code == search
                         select new Warehouse
                         {
                             Name = ct.Name,
                             CountryName = c.CountryName,
                             stateName = s.StateName,
                             CityName = cty.CityName,
                             DepartmentName = dt.Name,
                             CurrencyName=cr.Name

                         }).Distinct().ToPagedList(page ?? 1, 3);
            return query;
        }

        // GET: Warehouse/Create
        public IActionResult AddorEdit(int id=0)
        {
            ViewData["CityId"] = new SelectList(context.city, "CityId", "CityName");
            ViewData["StateId"] = new SelectList(context.state, "StateId", "StateName");
            ViewData["CountryId"] = new SelectList(context.country, "CountryId", "CountryName");
            ViewData["DepartmentId"] = new SelectList(context.department, "DeptId", "Name");
            ViewData["CurrencyId"] = new SelectList(context.currency, "CurrencyId", "Name");

            int Max = 0;
            if (id == 0)
            {
                Max = context.Warehouse.Select(p => p.WarehouseId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.warehouse = "WH001" + nextmax.ToString();
                return View(new Warehouse());
            }
            else
                return View(context.Warehouse.Find(id));
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("WarehouseId,Name,Code,BranchId,MangerID,Address,Address2,PostCode,StateId,CountryId,CityId,ContactPer,ContPerMobNo,ContPerEmail,WMFaxNo,WMDepartmentId,WMTeleNo,WMEmail,WMUrl,WMCurrencyId,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                if(warehouse.WarehouseId==0)
                {
                    warehouse.Status = AppConstant.Active;
                    warehouse.CreatedOn = System.DateTime.Now;
                    warehouse.ModifiedOn = System.DateTime.Now;
                    warehouse.IP = GETIP.GetIp();
                    warehouse.CompanyID = AppConstant.CompanyID;
                    context.Add(warehouse);

                }
                else
                {
                    warehouse.Status = AppConstant.Active;
                    warehouse.CreatedOn = System.DateTime.Now;
                    warehouse.ModifiedOn = System.DateTime.Now;
                    warehouse.IP = GETIP.GetIp();
                    warehouse.CompanyID = AppConstant.CompanyID;
                    context.Update(warehouse);
                }
            
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
              ViewData["StateId"] = new SelectList(context.state, "StateId", "StateName");
            ViewData["CountryId"] = new SelectList(context.country, "CountryId", "CountryName");
            ViewData["CityId"] = new SelectList(context.city, "CityId", "CityName");
            ViewData["DepartmentId"] = new SelectList(context.department, "DeptId", "Name");
            ViewData["CurrencyId"] = new SelectList(context.currency, "CurrencyId", "Name");
            return View(warehouse);
        }



        // GET: Warehouse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var warehouse = await context.Warehouse.FindAsync(id);
            context.Warehouse.Remove(warehouse);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        //public JsonResult GetState(int CountryId)
        //{
        //    List<State> StateList = new List<State>();
        //    StateList = (from s in context.state
        //                 where s.CountryId == CountryId
        //                 select s).ToList();
        //    StateList.Insert(0, new State { StateId = 0, StateName = "Select Any" });
        //    return Json(new SelectList(StateList, "StateId", "StateName"));
        //}
    }
}
