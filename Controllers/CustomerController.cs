﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SatyaMvc4Crud.Models;
using SatyaMvc4Crud.DataAccess;

namespace SatyaMvc4Crud.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [HttpGet]
        public ActionResult InsertCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertCustomer(Customer objCustomer)
        {
            objCustomer.BirthDate = Convert.ToDateTime(objCustomer.BirthDate);
            if (ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);
                //ViewData["result"] = result;
                TempData["result1"] = result;
                ModelState.Clear(); //Clearing model
                //return View();
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowAllCustomerDetails()
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            objCustomer.ShowallCustomer = objDB.Selectalldata();
            return View(objCustomer);
        }

        [HttpGet]
        public ActionResult Details(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();//calling class DBdata
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpGet]
        public ActionResult Edit(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(Customer objCustomer)
        {
            objCustomer.BirthDate = Convert.ToDateTime(objCustomer.BirthDate);
            if (ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.UpdateData(objCustomer);
                TempData["result2"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(String ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.DeleteData(ID);
            TempData["result3"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowAllCustomerDetails");
        }
    }
}