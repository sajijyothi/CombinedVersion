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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SCNEXTCoreApp.Controllers.Master
{
    public class SupplierController : Controller
    {
        //private readonly GeneralDbContext context;
        SupplierViewModel vm = new SupplierViewModel();
        private GeneralDbContext context;
        IPModel Ipadd = new IPModel();

        public SupplierController(GeneralDbContext context)
        {
            this.context = context;
        }

        // GET: Supplier
        public IEnumerable<Supplier> GetDetail(string search, int? page)
        {
            var query = (from u in context.Supplier
                         join ct in context.Address on u.SupID equals ct.TypeRefId
                         where ct.AddressAreaName == search || ct.AddressAreaCode == search || search == null
                         select new Supplier
                         {
                             
                             SupName = u.SupName


                         }).Distinct().ToPagedList(page ?? 1, 3);
            return query;
        }
        public IActionResult Index(string search, int? page)
        {
            return View(GetDetail(search, page));
        }
        // GET: Supplier/Create             
        public IActionResult AddorEdit(int id = 0)
        {
            var supplier = new Supplier();
            int Max = 0;
            if (id == 0)
            {
                Max = context.Supplier.Select(p => p.SupID).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.supplier = "Sup00" + nextmax.ToString();
                return View(new Supplier());

            }
            else
                return View(context.Supplier.Find(id));
        }
        public ActionResult Index11()
        {

            return View();
        }
        public ActionResult Create()
        {
            ViewData["TypeRefId"] = new SelectList(context.Supplier, "SupID", "SupName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]

        public async Task<IActionResult> Create(SupplierViewModel sm)
        {
           
            var supplier = new Supplier
            {
                SupName = sm.SupName,
                SupCode = sm.SupCode,
                SupTrnNo= sm.SupTrnNo,
                SupLoginEnable=sm.SupLoginEnable,
                Status = AppConstant.Active,
                CompanyID = AppConstant.CompanyID,
                CreatedOn = System.DateTime.Now,
                ModifiedOn = System.DateTime.Now,
                 IP = Ipadd.GetIp()
            };
            var addrs = new Address
            {
                TypeId = AppConstant.Supplier,
                TypeRefId = sm.SupID,
                AddressAprtNo =sm.AddressAprtNo,
                AddressFloorNo = sm.AddressFloorNo,
                AddressBuildingNo=sm.AddressBuildingNo,
                AddressBuildingName=sm.AddressBuildingName,
                AddressStreetName=sm.AddressStreetName,
                AddressStreetNo=sm.AddressStreetNo,
                AddressAreaCode=sm.AddressAreaCode,
                AddressAreaName=sm.AddressAreaName,
                AddressCity=sm.AddressCity,
                AddressDistrict=sm.AddressDistrict,
                AddressState=sm.AddressState,
                AddressCountry=sm.AddressCountry,
                AddressContactNo1=sm.AddressContactNo1,
                AddressContactNo2=sm.AddressContactNo2,
                AddressEmailId1=sm.AddressEmailId1,
                AddressEmailId2=sm.AddressEmailId2,
                AddressContactPerson1=sm.AddressContactPerson1,
                AddressContactPerson2=sm.AddressContactPerson2,
                AddressLatLoc=sm.AddressLatLoc,
                AddressLongLoc=sm.AddressLongLoc,
                AddressUrl=sm.AddressUrl,
                AddressClosestLandMark=sm.AddressClosestLandMark,
                AddressField1=sm.AddressField1,
                AddressField2 =sm.AddressField2,
                AddressField3 =sm.AddressField3,
                AddressField4 =sm.AddressField4,
                AddressField5 =sm.AddressField5,
                Status = AppConstant.Active,
                CompanyID = AppConstant.CompanyID,
                CreatedOn = System.DateTime.Now,
                ModifiedOn = System.DateTime.Now,
                IP = Ipadd.GetIp()
             };
            context.Supplier.Add(supplier);
            context.Address.Add(addrs);
            await context.SaveChangesAsync();
            ViewData["SupId"] = new SelectList(context.Supplier, "SupID", "SupName");

            return View();
        }

        //public async Task<IActionResult> AddorEdit([Bind("SupID,SupName,SupCode,SupTrnNo,SupAddressId,SupLoginEnable,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Supplier supplier)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (supplier.SupID == 0)
        //        {                                      
        //            supplier.Status = AppConstant.Active;
        //            supplier.CreatedOn = System.DateTime.Now;
        //            supplier.ModifiedOn = System.DateTime.Now;
        //            supplier.IP = Ipadd.GetIp();
        //            supplier.CompanyID = AppConstant.CompanyID;
        //            context.Add(supplier);
        //        }
        //        else
        //        {
        //            supplier.Status = AppConstant.Active;
        //            supplier.ModifiedOn = System.DateTime.Now;
        //            supplier.IP = Ipadd.GetIp();
        //            supplier.CompanyID = AppConstant.CompanyID;
        //            context.Update(supplier);
        //        }

        //         await context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(supplier);
        //}
        // GET: Supplier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var supplier = await context.Supplier.FindAsync(id);
            context.Supplier.Remove(supplier);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
