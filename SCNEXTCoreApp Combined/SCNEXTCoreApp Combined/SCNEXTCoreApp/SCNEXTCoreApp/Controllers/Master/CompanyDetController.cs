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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;

namespace SCNEXTCoreApp.Controllers.Master
{
    public class CompanyDetController : Controller
    {
        private readonly GeneralDbContext context;
        IPModel Ipadd = new IPModel();
      //  private readonly IFileProvider fileProvider;
         private readonly IHostingEnvironment hostingEnvironment;
    
        public CompanyDetController(GeneralDbContext context, IHostingEnvironment env)
        {
            this.context = context;
           
            hostingEnvironment = env;
        }

        // GET: CompanyDet
        public IActionResult Index(string searchBy, string searching, int? page)
        {

            if (searchBy == "Name")
            {
                return View(context.CompanyDet.Where(x => x.CompName.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(context.CompanyDet.Where(x => x.CompCode.Contains(searching) || searching == null).ToPagedList(page ?? 1, 3));
            }
        }

        
        // GET: CompanyDet/Create
        public IActionResult AddorEdit(int id=0)
        {
            ViewData["City"] = new SelectList(context.city, "CityID", "Name");
            ViewData["State"] = new SelectList(context.state, "StateID", "Name");
            ViewData["Country"] = new SelectList(context.country, "CountryID", "Name");

            int Max = 0;
            if (id == 0)
            {
                Max = context.CompanyDet.Select(p => p.CmpId).DefaultIfEmpty().Max();
                int nextmax = Max + 1;
                ViewBag.CompanyID = "SCNEXT-" + nextmax.ToString();
                ViewBag.compcode = "Cmp-C00" + nextmax.ToString();
                return View(new CompanyDet());
            }
            else
                return View(context.CompanyDet.Find(id));
        }

           [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> AddorEdit([Bind("CmpId,CompanyID,CompName,CompCode,CompTrnNo,CompAddress,CompCity,CompState,CompCountry,CompZipCode,CompPrefPhoneNo,CompAltPhoneNo,CompContactName,CompRefNameNo,CompLoginEnable,CompAddress2,compLogo,OrgTypeID,OrgID,LicenseType,UserLimit,DefWorkStartTime,DefWorkEndTime,FinStartDate,FinEndDate,CmpTimeZone,CompBussinessHr,MaxWrkHr,TrnNo,CreatedOn,CreatedBy,ModifiedBy,ModifiedOn,IP,Status")] CompanyDet companyDet,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if(companyDet.CmpId==0)
                {
                    
                    companyDet.Status = AppConstant.Active;
                    companyDet.CreatedOn = System.DateTime.Now;
                    companyDet.ModifiedOn = System.DateTime.Now;
                    companyDet.IP = Ipadd.GetIp();                 
                  
                    context.Add(companyDet);
                    await context.SaveChangesAsync();
                    if (file != null || file.Length != 0)
                    {
                        FileInfo fi = new FileInfo(file.FileName);
                        var newFilename = companyDet.CmpId + "_" + String.Format("{0:d}", (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                        var webPath = hostingEnvironment.WebRootPath;
                        var path = Path.Combine("", webPath + @"\ImageFiles\" + newFilename);
                        var pathToSave = @"/images/" + newFilename;
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        companyDet.compLogo = pathToSave;
                        context.Update(companyDet);
                        await context.SaveChangesAsync();
                    }
                }
                else
                {
                    companyDet.Status = AppConstant.Active;
                    companyDet.CreatedOn = System.DateTime.Now;
                    companyDet.ModifiedOn = System.DateTime.Now;
                    companyDet.IP = Ipadd.GetIp();
                    context.Update(companyDet);
                    await context.SaveChangesAsync();
                }
               

                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["City"] = new SelectList(context.city, "CityID", "Name");
            ViewData["State"] = new SelectList(context.state, "StateID", "Name");
            ViewData["Country"] = new SelectList(context.country, "CountryID", "Name");

            return View(companyDet);
        }

       
        // POST: CompanyDet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // GET: CompanyDet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var companydet = await context.CompanyDet.FindAsync(id);
            context.CompanyDet.Remove(companydet);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
