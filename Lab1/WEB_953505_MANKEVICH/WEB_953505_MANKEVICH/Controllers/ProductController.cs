using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WEB_953505_MANKEVICH.Entities;
using WEB_953505_MANKEVICH.Models;

namespace WEB_953505_MANKEVICH.Controllers
{
    public class ProductController : Controller
    {
        private List<Car> _cars;
        private List<CarGroup> _carGroups;

        private int _pageSize;

        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }

        public IActionResult Index(int? group, int pageNo = 1)
        {
            var carsFiltered = _cars.Where(d =>
                !group.HasValue || d.CarGroupId == group.Value);
            ViewData["Groups"] = _carGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Car>.GetModel(carsFiltered, pageNo,
                _pageSize));
        }

        private void SetupData()
        {
            _carGroups = new List<CarGroup>
            {
                new CarGroup {CarGroupId = 1, GroupName = "Купе"},
                new CarGroup {CarGroupId = 2, GroupName = "Седан"},
                new CarGroup {CarGroupId = 3, GroupName = "Универсал"},
                new CarGroup {CarGroupId = 4, GroupName = "Кабриолет"},
                new CarGroup {CarGroupId = 5, GroupName = "Хэтчбэк"}
            };

            _cars = new List<Car>
            {
                new()
                {
                    CarId = 1, ModelName = "4 series", ManufacturerName = "BMW",
                    CarGroupId = 1, Group = _carGroups[0], Image = "BMW4.jpeg"
                },
                new()
                {
                    CarId = 2, ModelName = "A6", ManufacturerName = "Audi",
                    CarGroupId = 2, Group = _carGroups[1], Image = "AudiA6.jpeg"
                },
                new()
                {
                    CarId = 3, ModelName = "Passat", ManufacturerName = "Volkswagen",
                    CarGroupId = 3, Group = _carGroups[2], Image = "VWPassat.jpeg"
                },
                new()
                {
                    CarId = 4, ModelName = "SL", ManufacturerName = "Mercedes-Benz",
                    CarGroupId = 4, Group = _carGroups[3], Image = "MBSL.jpeg"
                },
                new()
                {
                    CarId = 5, ModelName = "Civic", ManufacturerName = "Honda",
                    CarGroupId = 5, Group = _carGroups[4], Image = "HondaCivic.jpeg"
                }
            };
        }
    }
}