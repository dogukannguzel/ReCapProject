using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2010,DailyPrice=15,Description="2010 model beyaz BMW araba"},
            new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=15,Description="2010 model kırmızı BMW araba"},
            new Car{Id=3,BrandId=2,ColorId=2,ModelYear=2014,DailyPrice=15,Description="2014 model kırmızı Mercedes araba"},
            new Car{Id=4,BrandId=3,ColorId=3,ModelYear=2010,DailyPrice=15,Description="2010 model gri Renault araba"},
            new Car{Id=5,BrandId=4,ColorId=4,ModelYear=2018,DailyPrice=15,Description="2018 model siyah Wolkswagen araba"},};
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void delete(Car car)
        {
            var result = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(result);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Uptade(Car car)
        {
            var result = _cars.SingleOrDefault(c => c.Id == car.Id);

            result.ColorId = car.ColorId;
            // vs .....


        }
    }
}
