﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalMS.Data;
using HospitalMS.Models;
using HospitalMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalMS.Controllers
{
    public class DesignationController : Controller
    {
        private readonly ApplicationDbContext db;

        public DesignationController(ApplicationDbContext context)
        {
            db = context;
        }

        [BindProperty]
        public Designation Designation { get; set; }


        public async Task<IActionResult> Index(string sortParam, string searchParam, int studentPage = 1, int PageSize = 9)
        {
            DesignationViewModel DesignationVM = new DesignationViewModel()
            {
                Designations = new List<Models.Designation>()
            };
            DesignationVM.Designations = await db.Designations.ToListAsync();

            if (searchParam != null)
            {
                DesignationVM.Designations = DesignationVM.Designations.Where(a => a.DesignationName.ToLower().Contains(searchParam.ToLower())).ToList();
            }

            StringBuilder param = new StringBuilder();
            param.Append("/Designation?studentPage=:");

            param.Append("&searchParam=");
            if (searchParam != null)
            {
                param.Append(searchParam);

            }

            param.Append("&sortParam=");
            if (sortParam != null)
            {
                param.Append(sortParam);
            }

            if (PageSize <= 0)
            {
                PageSize = 9;
            }

            ViewBag.PageSize = PageSize;

            param.Append("&PageSize=");
            if (PageSize != 0)
            {
                param.Append(PageSize);
            }
            var count = DesignationVM.Designations.Count;

            if (sortParam == "SortDec")
            {
                DesignationVM.Designations = DesignationVM.Designations.OrderByDescending(p => p.DesignationName)
                .Skip((studentPage - 1) * PageSize)
                .Take(PageSize).ToList();
                ViewBag.sortParamView = "SortDec";
            }
            else
            {
                DesignationVM.Designations = DesignationVM.Designations.OrderBy(p => p.DesignationName)
                .Skip((studentPage - 1) * PageSize)
                .Take(PageSize).ToList();
                ViewBag.sortParamView = "SortAsc";
            }

            DesignationVM.PagingInfo = new PagingInfo()
            {
                CurrentPage = studentPage,
                ItemsPerPage = PageSize,
                TotalItems = count,
                urlParam = param.ToString(),
                //PagerSize = 5,

            };
            return View(DesignationVM);
        }

        public IActionResult Create()
        {
            ViewBag.returnUrl = (Request.Headers["Referer"].ToString());
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                db.Designations.Add(Designation);
                await db.SaveChangesAsync();
                return Redirect(returnUrl);
            }
            else
            {
                return View();
            }

        }

        public async Task<IActionResult> Update(int id)
        {
            var designation = await db.Designations.FindAsync(id);
            //ViewData["Reffer"] = Request.Headers["Referer"].ToString();
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View(designation);
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateData(string iD, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var obj = (from data in db.Designations where data.DesignationID == int.Parse(iD) select data).FirstOrDefault();
                obj.DesignationID = int.Parse(iD);
                obj.DesignationName = Designation.DesignationName;

                await db.SaveChangesAsync();
                return Redirect(returnUrl);
                //return RedirectToAction("Index");
            }


            //string qs = iD.ToString();

            return View(Designation);


            //return RedirectToAction("Index", new { studentId = iD });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var designation = await db.Designations.FindAsync(id);

            //ViewData["Reffer"] = Request.Headers["Referer"].ToString();

            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View(designation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteData(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                db.Designations.Remove(Designation);
                await db.SaveChangesAsync();
                return Redirect(returnUrl);
            }


            //string qs = iD.ToString();

            return View(Designation);


            //return RedirectToAction("Index", new { studentId = iD });
        }

        //public IActionResult Search(string search)
        //{
        //    return RedirectToAction("Index", new { abc = search });
        //}

        public async Task<IActionResult> Details(int id)
        {

            var designation = await db.Designations.FindAsync(id);
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View(designation);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsData(string iD, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var obj = (from data in db.Designations where data.DesignationID == int.Parse(iD) select data).FirstOrDefault();
                obj.DesignationID = int.Parse(iD);
                obj.DesignationName = Designation.DesignationName;

                await db.SaveChangesAsync();
                return Redirect(returnUrl);

            }


            //string qs = iD.ToString();

            return View(Designation);


            //return RedirectToAction("Index", new { studentId = iD });
        }


    }
}