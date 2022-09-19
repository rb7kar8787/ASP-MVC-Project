using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly DatabaseContext _context;

        public StudentController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult StudentList()
        {
            try
            {
                //var stdList = _context.Student_table.ToList();
                var stdList = from a in _context.Student_table
                              join b in _context.Department_table
                              on a.DeptID equals b.ID
                              into Dep

                              from b in Dep.DefaultIfEmpty()

                              select new Student
                              {
                                  ID = a.ID,
                                  Name = a.Name,
                                  lastname = a.lastname,
                                  Email = a.Email,
                                  Mobile = a.Mobile,
                                  Description = a.Description,
                                  DeptID = a.DeptID,
                                  Department = b == null ? "" : b.Department
                              };
                return View(stdList);

            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }

        public IActionResult Create()
        {
            loadDDL();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Student_table.Add(obj);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("StudentList");
                }
                return View();
                

            }
            catch(Exception ex)
            {
                
                return RedirectToAction("StudentList");
                
            }
        }



        public void loadDDL()
        {
            try
            {
               List<Departments> dpList = new List<Departments>();
                dpList = _context.Department_table.ToList();

                dpList.Insert(0, new Departments { ID = 0, Department="Please Select" });

                ViewBag.DepList = dpList;
            }catch(Exception ex)
            {

            }
        }
    }
}
