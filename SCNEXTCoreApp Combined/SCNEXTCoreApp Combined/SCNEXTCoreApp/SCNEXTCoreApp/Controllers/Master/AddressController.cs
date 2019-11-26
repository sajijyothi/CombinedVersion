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
    public class AddressController : Controller
    {
        private readonly GeneralDbContext context;
        IPModel Ipadd = new IPModel();
        public AddressController(GeneralDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Address> GetDetail(string search, int? page)
        {
            var query = (from u in context.Supplier
                         join ct in context.Address on u.SupID equals ct.TypeRefId
                         where ct.AddressAreaName == search || ct.AddressAreaCode == search || search == null
                         select new Address
                         {
                             AddressAreaName = ct.AddressAreaName,
                             AddressAreaCode = ct.AddressAreaCode,
                             


                         }).Distinct().ToPagedList(page ?? 1, 3);
            return query;
        }
        public IActionResult Index(string search, int? page)
        {
            return View(GetDetail(search, page));
        }      


        // GET: Address/Create
        [HttpGet]
        public IActionResult AddorEdit(int id = 0)
        {
            ViewData["SupId"] = new SelectList(context.Supplier, "SupID", "SupName");

            int Max = 0;
            if (id == 0)
            {
                Max = context.Address.Select(p => p.AddressId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.Address = "Add00" + nextmax.ToString();
                return View(new Address());
            }
            else
                return View(context.Address.Find(id));
        }
        // POST: Address/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("AddressId,AddressAprtNo,AddressFloorNo,AddressBuildingNo,AddressBuildingName,AddressStreetName,AddressStreetNo,AddressAreaCode,AddressAreaName,AddressCity,AddressDistrict,AddressState,AddressCountry,AddressContactNo1,AddressContactNo2,AddressEmailId1,AddressEmailId2,AddressContactPerson1,AddressContactPerson2,AddressLatLoc,AddressLongLoc,AddressUrl,AddressClosestLandMark,AddressField1,AddressField2,AddressField3,AddressField4,AddressField5,TypeId,TypeReferenceId")] Address address)
        {
            if (ModelState.IsValid)
            {
                if (address.AddressId == 0)
                {
                    address.TypeId = AppConstant.Supplier;
                    address.Status = AppConstant.Active;
                    address.CreatedOn = System.DateTime.Now;
                    address.ModifiedOn = System.DateTime.Now;
                    address.IP = Ipadd.GetIp();
                    address.CompanyID = AppConstant.CompanyID;
                    context.Add(address);
                }
                else
                {
                    //address.TypeId = AppConstant.Supplier;
                    address.Status = AppConstant.Active;
                    address.ModifiedOn = System.DateTime.Now;
                    address.IP = Ipadd.GetIp();
                    address.CompanyID = AppConstant.CompanyID;
                    context.Update(address);
                }
                
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupId"] = new SelectList(context.Supplier, "SupID", "SupName");

            return View(address);
        }

        // GET: Address/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Address = await context.Address.FindAsync(id);
            context.Address.Remove(Address);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
