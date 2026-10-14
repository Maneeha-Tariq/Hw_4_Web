using Microsoft.AspNetCore.Mvc;
using Hw_4_Web.Models;
namespace Hw_4_Web.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> availableCars = new List<Car>
        {
            new Car{Id = 1,Name = "Alto",PricePerDay = 3000},
            new Car{Id = 2,Name = "Corolla",PricePerDay = 6000},
            new Car{Id = 3,Name = "Civic",PricePerDay = 8000}
        };
        private static List<Car> bookedCars = new List<Car>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(availableCars);
        }
        [HttpPost]
        public IActionResult Book(int id)
        {
            Car car = null;
            foreach(Car c in availableCars)
            {
                if(c.Id==id)
                {
                    car = c;
                    break;
                }
            }

            if(car!=null)
            {
                availableCars.Remove(car);
                bookedCars.Add(car);
                return RedirectToAction("Booked");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
    }
}
