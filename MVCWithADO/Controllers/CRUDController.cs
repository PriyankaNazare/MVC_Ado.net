using MVCWithADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithADO.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        CRUDModel model = new CRUDModel();
        public ActionResult Index()
        {
            
            DataTable dt = model.GetAllStudents();
            return View("Home",dt);
        }

        public ActionResult Insert()
        {
            return View("Create");
        }

        public ActionResult InsertRecord(FormCollection frm,string action)
        {
            if (action == "Submit")
            {
                string name = frm["txtName"];
                int age = Convert.ToInt32(frm["txtAge"]);
                string gender = frm["gender"];
                int status = model.InsertStudent(name, age, gender);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");

        }

        public ActionResult Edit(int StudentId)
        {
            DataTable dt = model.GetStudentById(StudentId);
            return View("Edit", dt);
        }

        public ActionResult UpdateRecord(FormCollection frm,string action)
        {
            if (action == "Submit")
            {
                string name = frm["txtName"];
                int age = Convert.ToInt32(frm["txtAge"]);
                string gender = frm["gender"];
                int id = Convert.ToInt32(frm["hdnId"]);
                int status = model.UpdateStudent(id, name, age, gender);
                return RedirectToAction("Index");

            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult Delete(int StudentId)
        {
            int status = model.DeleteStudent(StudentId);
            return RedirectToAction("Index");
        }

    }
}