using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private List<City> _citiesList = new List<City>();
        private List<Area> _areaList = new List<Area>();


        public HomeController()
        {
            _citiesList = new List<City>() 
            { 
                new City  { Id = 1,Name = "Cairo"},
                new City  { Id = 2,Name = "Alex"},
                new City  { Id = 3,Name = "Giza"}
            };

            _areaList = new List<Area>() 
            {
                new Area  { Id = 1,Name = "Heliopolis District"  ,CityId=1 },
                new Area  { Id = 2,Name = "Nasr City District" ,CityId=1 },
                new Area  { Id = 3,Name = "Abdeen District",CityId=1 },

                new Area  { Id = 4,Name = "Nozha District"  ,CityId=2 },
                new Area  { Id = 5,Name = "Al-Mamoura District" ,CityId=2 },
                new Area  { Id = 6,Name = "Mansheya District",CityId=2 },

                new Area  { Id = 7,Name = "Haram District"  ,CityId=3 },
                new Area  { Id = 8,Name = "Faisal District" ,CityId=3 },
                new Area  { Id = 9,Name = "Bulaq District",CityId=3 }
            };
        }

        public IActionResult Index()
        {
            var ViewModel = new FormViewModel
            {
                Cities = _citiesList.ToList()
            };


            return View(ViewModel);
        }

        [HttpGet]
        public IActionResult GetAries(int cityId)
        {

            var areas = _areaList.Where(a => a.CityId == cityId).OrderBy(o => o.Name).ToList();
         
            return Ok(areas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}