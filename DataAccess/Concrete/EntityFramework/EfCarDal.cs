using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDto()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brand
                             on c.BrandId equals b.Id
                             join cl in context.Color
                             on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 CarId=c.Id,
                                 CarName = c.Description,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
                             
            }
        }
    }
}
