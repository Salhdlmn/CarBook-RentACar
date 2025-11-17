using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticsInterface;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

 

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
                    //Select Avg(Amount) from CarPricings where PricingID=(Select PricingID From Pricings Where Name='Günlük')
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }
     

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count(); 
            return value;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var value = _context.Blogs
                .OrderByDescending(b => b.Comments.Count)
                .Select(b => b.Title)
                .FirstOrDefault();
            return value;
        }

        public int GetBrandCount()
        {
           var value = _context.Brands.Count();
            return value;   
        }

        public string GetBrandNameByMaxCar()
        {
           var value = _context.Cars.GroupBy(x => x.Brand.Name)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value =_context.CarPricings
                .OrderByDescending(cp => cp.Amount)
                .Select(cp => new { cp.Car.Brand.Name, cp.Car.Model })
                .FirstOrDefault();
            return $"{value.Name} {value.Model}";
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = _context.CarPricings
                .OrderBy(cp => cp.Amount)
                .Select(cp => new { cp.Car.Brand.Name, cp.Car.Model })
                .FirstOrDefault();
            return $"{value.Name} {value.Model}";
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
          var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
           var value= _context.Cars.Where(x=>x.Km<1000).Count();
            return value;
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            var value = _context.Cars.Where(x=>x.Transmission=="Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
