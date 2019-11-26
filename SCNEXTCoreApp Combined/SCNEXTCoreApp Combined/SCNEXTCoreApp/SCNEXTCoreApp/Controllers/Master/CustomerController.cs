using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using SCNEXTCoreApp.Data.Constant;
using SCNEXTCoreApp.Data.Master;
using SCNEXTCoreApp.Models.Master;
using SCNEXTCoreApp.Models.ViewModel;
using static SCNEXTCoreApp.Models.ViewModel.UserDetails;

namespace SCNEXTCoreApp.Controllers.Master
{
    public class CustomerController : Controller
    {
        private readonly GeneralDbContext _context;

        public CustomerController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: Customer
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Customer.ToListAsync());
        //}

        public IActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == "CustomerName")
                return View(_context.Customer.Where(m => m.CustName == search || search == null)
                    .ToPagedList(page ?? 1, 3));
            else
                return View(_context.Customer.Where(m => m.CustCode == search || search == null)
                    .ToPagedList(page ?? 1, 3));
        }



        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MyViewModel model)
        {
            if (ModelState.IsValid)
            {
                {
                    Customer cus = new Customer();
                    cus.CustName = model.CustName;
                    cus.CustCode = model.CustCode;
                    cus.CustTrnNo = model.CustTrnNo;
                    cus.CustLoginEnable = model.CustLoginEnable;
                    cus.Status = AppConstant.Active;
                    cus.CompanyID = AppConstant.CompanyID;
                    cus.CreatedOn = DateTime.Now;
                    cus.ModifiedOn = DateTime.Now;
                    cus.IP = GetIPAddress.getExternalIp();
                    _context.Customer.Add(cus);
                    await _context.SaveChangesAsync();
                }
                {
                    Address add = new Address();
                    add.AddressAprtNo = model.AddressAprtNo;
                    add.AddressFloorNo = model.AddressFloorNo;
                    add.AddressBuildingNo = model.AddressBuildingNo;
                    add.AddressBuildingName = model.AddressBuildingName;
                    add.AddressStreetName = model.AddressStreetName;
                    add.AddressStreetNo = model.AddressStreetNo;
                    add.AddressAreaCode = model.AddressAreaCode;
                    add.AddressAreaName = model.AddressAreaName;
                    add.AddressCity = model.AddressCity;
                    add.AddressDistrict = model.AddressDistrict;
                    add.AddressState = model.AddressState;
                    add.AddressCountry = model.AddressCountry;
                    add.AddressContactNo1 = model.AddressContactNo1;
                    add.AddressContactNo2 = model.AddressContactNo2;
                    add.AddressEmailId1 = model.AddressEmailId1;
                    add.AddressEmailId2 = model.AddressEmailId2;
                    add.AddressContactPerson1 = model.AddressContactPerson1;
                    add.AddressContactPerson2 = model.AddressContactPerson2;
                    add.AddressLatLoc = model.AddressLatLoc;
                    add.AddressLongLoc = model.AddressLongLoc;
                    add.AddressUrl = model.AddressUrl;
                    add.AddressClosestLandMark = model.AddressClosestLandMark;
                    add.AddressField1 = model.AddressField1;
                    add.AddressField2 = model.AddressField2;
                    add.AddressField3 = model.AddressField3;
                    add.AddressField4 = model.AddressField4;
                    add.AddressField5 = model.AddressField5;
                    _context.Address.Add(add);
                    await _context.SaveChangesAsync();
                }
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(model);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer cus = new Customer();
                cus.ModifiedOn = DateTime.Now;
                cus.IP = GetIPAddress.getExternalIp();
                _context.Customer.Update(cus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }


        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
