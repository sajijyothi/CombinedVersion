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
    public class pimcategorytypeController : Controller
    {
        private readonly GeneralDbContext context;
         IPModel GETIP = new IPModel();
        public pimcategorytypeController(GeneralDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<pimcategorytype> GetDetail(string search,int? page)
        {
              var query = (from u in context.pimcategory
                         join ct in context.pimcategorytype on u.PimCatID equals ct.PimCatID
                         where ct.Name==search||ct.Code==search||search==null
                         select new pimcategorytype
                         {
                             Name=ct.Name,
                             Code=ct.Code,
                             Description=ct.Description,
                             pimcategoryName = u.Name                           
                             

                         }).Distinct().ToPagedList(page ?? 1, 3);
            return query;
        }
        public IActionResult Index(string search,int? page)
        {
            return View(GetDetail(search,page));
        }

       
        // GET: pimcategorytype/Create
        [HttpGet]
        public IActionResult AddorEdit(int id = 0)
        {
            ViewData["PimCatID"] = new SelectList(context.pimcategory, "PimCatID", "Name");
            int Max = 0;
            if (id == 0)
            {
                Max = context.pimcategorytype.Select(p => p.PimCatTypeID).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.pimcategorytype = "pmcttp" + nextmax.ToString();
                return View(new pimcategorytype());
            }
            else
                return View(context.pimcategorytype.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("PimCatTypeID,Name,Code,Description,CompanyID,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,Status,IP,VatStatus,VatType,PimCatID")] pimcategorytype pimcategorytype)
        {
            if (ModelState.IsValid)
            {
                if (pimcategorytype.PimCatTypeID == 0)
                {
                    pimcategorytype.Status = AppConstant.Active;
                    pimcategorytype.CreatedOn = System.DateTime.Now;
                    pimcategorytype.ModifiedOn = System.DateTime.Now;
                    pimcategorytype.IP = GETIP.GetIp();
                    pimcategorytype.CompanyID = AppConstant.CompanyID;
                    context.Add(pimcategorytype);
                }
                else
                {
                    pimcategorytype.Status = AppConstant.Active;
                    pimcategorytype.ModifiedOn = System.DateTime.Now;
                    pimcategorytype.IP = GETIP.GetIp();
                    pimcategorytype.CompanyID = AppConstant.CompanyID;
                   context.Update(pimcategorytype);
                }
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["PimCatID"] = new SelectList(context.pimcategory, "PimCatID", "Name", pimcategorytype.pimcategory);
            return View(pimcategorytype);
        }


        // GET: pimcategorytype/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pimcategorytype = await context.pimcategorytype.FindAsync(id);
            context.pimcategorytype.Remove(pimcategorytype);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        public JsonResult CheckCode(string Code)
        {
            pimcategorytype entities = new pimcategorytype();
            bool isValid = !entities.Code.Equals(Code, StringComparison.CurrentCultureIgnoreCase);
            return Json(isValid);
        }
    }
}
