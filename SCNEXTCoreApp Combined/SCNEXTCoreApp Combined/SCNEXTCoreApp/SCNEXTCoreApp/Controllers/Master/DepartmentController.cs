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
    public class DepartmentController : Controller
    {
        private readonly GeneralDbContext context;
       // private readonly AppConstant Appcontext;
        IPModel GETIP = new IPModel();
        public DepartmentController(GeneralDbContext context)
        {
            this.context = context;
        }
        
        public ActionResult Index(string searchBy, string searching, int? page)
        {
            if (searchBy == "Name")
            {
                return View(context.department.Where(x => x.Name.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(context.department.Where(x => x.Code.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));

            }

        }
        // GET: Department/Create
        [HttpGet]
        public IActionResult AddorEdit(int id = 0)
        {
            int Max = 0;
            if (id == 0)
            {
                Max = context.department.Select(p => p.DeptId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.Department = "Dept" + nextmax.ToString();
                return View(new Department());
            }
            else
                return View(context.department.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("DeptId,Name,Code,Description,Status,CompanyID,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP")] Department department)
        {
            if (ModelState.IsValid)
            {
                if (department.DeptId == 0)
                {
                    department.Status = AppConstant.Active;
                    // department.CreatedBy = userId;
                    department.CreatedOn = System.DateTime.Now;
                    department.ModifiedOn = System.DateTime.Now;
                    //department.IP = GETIP.GetIPAddress();
                    department.IP = GETIP.GetIp();
                    department.CompanyID = AppConstant.CompanyID;
                    context.Add(department);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));


                }
                else
                {
                    department.Status = AppConstant.Active;
                    department.ModifiedOn = System.DateTime.Now;
                    department.IP = GETIP.GetIp();
                    department.CompanyID = AppConstant.CompanyID;
                    context.Update(department);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(department);
        }
        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Department = await context.department.FindAsync(id);
            context.department.Remove(Department);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

    }     
}