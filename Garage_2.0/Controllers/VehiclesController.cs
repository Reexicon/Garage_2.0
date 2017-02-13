using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage_2._0.DAL;
using Garage_2._0.Models;
namespace Garage_2._0.Controllers
{
    
   
    public class VehiclesController : Controller
    {
        const int MaxNumberVehicles = 35;
        private VehiclesContext db = new VehiclesContext();

        // GET: Vehicles
        public ActionResult Index(string sortOrder,string searchReg,string searchColor, Models.Type? searchType)
        {
            int numberOfVehicles = db.Vehicles.Count();


            //if (MaxNumberVehicles > numberOfVehicles)
            //{
            //    ViewBag.NumberOfVehicles = $"The Garage have {numberOfVehicles} of max {MaxNumberVehicles}";
            //    ViewBag.Color = "Blue";
            //}
            //else
            //{
            //    ViewBag.NumberOfVehicles = $"The Garage is FULL {MaxNumberVehicles} Vehicles";
            //    ViewBag.Color = "Red";
            //}

            numberVehicleMessage();

            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "VehicleType_desc" : "";
            ViewBag.VehicleTypeSortParm = sortOrder == "VehicleType" ? "VehicleType_desc" : "VehicleType";
            ViewBag.RegistrationNumberSortParm = sortOrder == "RegistrationNumber" ? "RegistrationNumber_desc" : "RegistrationNumber";
            ViewBag.ColorSortParm = sortOrder == "Color" ? "Color_desc" : "Color";
            ViewBag.WhenParkedSortParm = sortOrder == "WhenParked" ? "WhenParked_desc" : "WhenParked";

            ViewBag.SearchReg = searchReg;
            ViewBag.SearchColor = searchColor;
            ViewBag.SearchType = searchType;

            var vehicles = from v in db.Vehicles
                           select v;
            if (!String.IsNullOrEmpty(searchReg))
            {
                vehicles = vehicles.Where(v => v.RegistrationNumber.Contains(searchReg)
                                       //|| v.Color.Contains(searchColor)
                                       );
            }
            if (!String.IsNullOrEmpty(searchColor))
            {
                vehicles = vehicles.Where(v => v.Color.Contains(searchColor)
                                       );
            }
            if (searchType != null)
            {
                vehicles = vehicles.Where(v => v.VehicleType == searchType);
                                       
            }

            switch (sortOrder)
            {
                case "VehicleType":
                    vehicles = vehicles.OrderBy(v => v.VehicleType);
                    break;
                case "VehicleType_desc":
                    vehicles = vehicles.OrderByDescending(v => v.VehicleType);
                    break;
                case "RegistrationNumber":
                    vehicles = vehicles.OrderBy(v => v.RegistrationNumber);
                    break;
                case "RegistrationNumber_desc":
                    vehicles = vehicles.OrderByDescending(v => v.RegistrationNumber);
                    break;
                case "Color":
                    vehicles = vehicles.OrderBy(v => v.Color);
                    break;
                case "Color_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Color);
                    break;
                case "WhenParked":
                    vehicles = vehicles.OrderBy(v => v.WhenParked);
                    break;
                case "WhenParked_desc":
                    vehicles = vehicles.OrderByDescending(v => v.WhenParked);
                    break;
                default:
                    vehicles = vehicles.OrderBy(v => v.VehicleType);
                    break;
            }
            return View(vehicles.ToList());
        }

        // GET: Departments Summary
        public ActionResult Statistics()
        {

            var model = db.Vehicles.GroupBy(x => x.VehicleType)
                .Select(x => new StatisticsForVehicleTypesVM
                {
                    VehicleType = x.Key,
                    QuantityByType = x.Distinct().Count()
                });
            var vehicles = from v in db.Vehicles
                           select v;
            int SumOfWheels = 0;
            double SumOfMinutes = 0;
            foreach (var vehicle in vehicles)
            {
                SumOfWheels += vehicle.Wheels;
                SumOfMinutes += (DateTime.Now - vehicle.WhenParked).TotalMinutes;
            }

            ViewBag.SumOfWheels = SumOfWheels;
            ViewBag.SumOfMinutes = Convert.ToInt32(SumOfMinutes).ToString("C", System.Globalization.CultureInfo.CurrentCulture);

            return View(model);
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vehicle vehicle = db.Vehicles.Find(id);

            ViewBag.payment = Math.Truncate((DateTime.Now - vehicle.WhenParked).TotalMinutes) + " Kronor";

            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {

            numberVehicleMessage();

            //int numberOfVehicles = db.Vehicles.Count();

            //if (MaxNumberVehicles > numberOfVehicles)
            //{
            //    ViewBag.NumberOfVehicles = $"The Garage have {numberOfVehicles} of max {MaxNumberVehicles}";
            //    ViewBag.Color = "Blue";
            //}
            //else
            //{
            //    ViewBag.NumberOfVehicles = $"The Garage is FULL {MaxNumberVehicles} Vehicles";
            //    ViewBag.Color = "Red";
            //}
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationNumber,VehicleType,Brand,Color,Wheels,WhenParked")] Vehicle vehicle)
        {
           
            int numberOfVehicles = db.Vehicles.Count();

            numberVehicleMessage();

            //if (MaxNumberVehicles > numberOfVehicles)
            //{
            //    ViewBag.NumberOfVehicles = $"The Garage have {numberOfVehicles} of max {MaxNumberVehicles}";
            //    ViewBag.Color = "Blue";
            //}
            //else
            //{
            //    ViewBag.NumberOfVehicles = $"The Garage is FULL {MaxNumberVehicles} Vehicles";
            //    ViewBag.Color = "Red";
            //}

            if (ModelState.IsValid && (MaxNumberVehicles > numberOfVehicles))
            {
                vehicle.WhenParked = DateTime.Now;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(vehicle);
        }

        private void numberVehicleMessage()
        {
            int numberOfVehicles = db.Vehicles.Count();

            if (MaxNumberVehicles > numberOfVehicles)
            {
                ViewBag.NumberOfVehicles = $"The Garage have {numberOfVehicles} of max {MaxNumberVehicles} Vehicles";
                ViewBag.Color = "Blue";
            }
            else
            {
                ViewBag.NumberOfVehicles = $"The Garage is FULL {MaxNumberVehicles} Vehicles";
                ViewBag.Color = "Red";
            }
        }


        //// GET: Vehicles/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    if (vehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicle);
        //}

        //// POST: Vehicles/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,RegistrationNumber,VehicleType,Brand,Color,Wheels,WhenParked")] Vehicle vehicle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vehicle).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(vehicle);
        //}

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Receipt", vehicle);
        }

        public ActionResult Receipt(Vehicle vehicle)
        {
            ReceiptModel model = new ReceiptModel();
            model.Vehicle = vehicle;
            model.Cost = Convert.ToInt32((DateTime.Now - vehicle.WhenParked).TotalMinutes).ToString("C", System.Globalization.CultureInfo.CurrentCulture);

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
