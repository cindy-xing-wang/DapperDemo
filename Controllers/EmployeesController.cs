﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationDapper.Data;
using WebApplicationDapper.Models;
using WebApplicationDapper.Repository;

namespace WebApplicationDapper.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ICompanyRepository _compRepo;
        private readonly IEmployeeRepository _empRepo;

        [BindProperty]
        public Employee Employee { get; set; }

        public EmployeesController(ICompanyRepository compRepo, IEmployeeRepository empRepo)
        {
            _compRepo = compRepo;
            _empRepo = empRepo;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(_empRepo.GetAll());
        }


        public IActionResult Create()
        {
            IEnumerable<SelectListItem> companyList = _compRepo.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.CompanyId.ToString()
            });
            ViewBag.CompanyList = companyList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePOST()
        {
            if (ModelState.IsValid)
            {
                _empRepo.Add(Employee);
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = _empRepo.Find(id.GetValueOrDefault());
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Address,City,State,PostalCode")] Employee company)
        {
            if (id != Employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _empRepo.Update(Employee);
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _empRepo.Remove(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }

    }
}
