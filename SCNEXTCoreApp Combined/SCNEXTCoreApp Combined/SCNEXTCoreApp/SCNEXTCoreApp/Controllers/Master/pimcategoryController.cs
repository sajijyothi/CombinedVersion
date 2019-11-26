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
    public class pimcategoryController : Controller
    {
        private readonly GeneralDbContext context;
       // private readonly AppConstant Appcontext;
        IPModel GETIP = new IPModel();
        public pimcategoryController(GeneralDbContext context)
        {
            this.context = context;
        }

        // GET: pimcategory
        public ActionResult Index(string searchBy, string searching, int? page)
        {
            if (searchBy == "Name")
            {
                return View(context.pimcategory.Where(x => x.Name.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(context.pimcategory.Where(x => x.Code.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));

            }

        }
        // GET: pimcategory/Create
        public IActionResult AddorEdit(int id = 0)
        {
            int Max = 0;
            if (id == 0)
            {
                Max = context.pimcategory.Select(p => p.PimCatID).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.pimcategory = "pimcat" + nextmax.ToString();            
                return View(new pimcategory());
            }
            else
                return View(context.pimcategory.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("PimCatID,Name,Code,Description,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP,VatStatus,VatType")] pimcategory pimcategory)
        {
            if (ModelState.IsValid)
            {
                if (pimcategory.PimCatID == 0)
                {
                 // pimcategory.Status = AppConstant.Active;
                    pimcategory.CreatedOn = System.DateTime.Now;
                    pimcategory.ModifiedOn = System.DateTime.Now;
                    pimcategory.IP = GETIP.GetIp();
                    pimcategory.CompanyID = AppConstant.CompanyID;
                    context.Add(pimcategory);
                    ViewData["msg"] = "Data Added successfully";
                }
                else
                {
                 // pimcategory.Status = AppConstant.Active;
                    pimcategory.ModifiedOn = System.DateTime.Now;
                    pimcategory.IP = GETIP.GetIp();
                    pimcategory.CompanyID = AppConstant.CompanyID;
                     context.Update(pimcategory);
                }
               
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pimcategory);
        }


        // GET: pimcategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pimcatergory = await context.pimcategory.FindAsync(id);
            context.pimcategory.Remove(pimcatergory);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pimcategoryExists(int id)
        {
            return context.pimcategory.Any(e => e.PimCatID == id);
        }
    }
}
