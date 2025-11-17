using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetLast5CarsWithQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var cars = _carRepository.GetLast5CarsWithBrands();
            var result = cars.Select(car => new GetCarWithBrandQueryResult
            {
                CarID = car.CarID,
                BigImageUrl = car.BigImageUrl,
                BrandName = car.Brand.Name,
                CoverImageUrl = car.CoverImageUrl,
                Fuel = car.Fuel,
                Km = car.Km,
                Luggage = car.Luggage,
                Model = car.Model,
                Seat = car.Seat,
                Transmission = car.Transmission
            }).ToList();
            return result;
        }

    }
}
