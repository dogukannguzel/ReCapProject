using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface ICarDal
    {

        void Add(Car car);

        void delete(Car car);

        void Uptade(Car car);

        List<Car> GetAll();

    }
}
