using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreRepo.Models;
using coreRepo.Infrastructure;

namespace coreRepo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee _employee;

        public HomeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employee = _employee.GelAll();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _employee.Insert(employee);
            _employee.Save();

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var employee = _employee.GetById(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _employee.Delete(employee);
            _employee.Save();
            return View();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var employee = _employee.GetById(Id);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var employee = _employee.GetById(Id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _employee.Update(employee);
            _employee.Save();
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {

            List<Case> Cases = new List<Case>()
            {
                new Case(){ Year = 2001, Agency = "Agency1", Attorney="Atticus Finch", CaseNumber = 1},
                new Case(){ Year = 2001, Agency = "Agency1", Attorney="Atticus Finch", CaseNumber = 2},
                new Case(){ Year = 2001, Agency = "Agency1", Attorney="Ben Matlock", CaseNumber = 3},
                new Case(){ Year = 2002, Agency = "Agency1", Attorney="Atticus Finch", CaseNumber = 99},
                new Case(){ Year = 2002, Agency = "Agency1", Attorney="Ben Matlock", CaseNumber = 22},
                new Case(){ Year = 2002, Agency = "Agency2", Attorney="Johnny Cochran", CaseNumber = 12},
                new Case(){ Year = 2003, Agency = "Agency2", Attorney="Mark Geragos", CaseNumber = 14},
                new Case(){ Year = 2003, Agency = "Agency3", Attorney="Robert Shapiro", CaseNumber = 29}
            };

            //var caseList = from c in Cases
            var CaseVM = from c in Cases
                           group c by new { c.Year } into yrgrp
                           orderby yrgrp.Key.Year
                           select new
                           {
                               Year = yrgrp.Key.Year,
                               Agencies = from d in yrgrp
                                          group d by new { d.Agency } into agencygrp
                                          select new
                                          {
                                              Agency = agencygrp.Key.Agency,
                                              Total = agencygrp.Count(),
                                              Attorneys = from e in agencygrp
                                                          group e by e.Attorney into attorneygrp
                                                          select new
                                                          {
                                                              Attorney = attorneygrp.Key,
                                                              Cases = attorneygrp,
                                                              Total = attorneygrp.Count()

                                                          }

                                          }
                           };
            /*ViewBag.caseList = caseList;
            return View();*/
            //return View(caseList);
            return View(CaseVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
