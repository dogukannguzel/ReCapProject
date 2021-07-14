using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
  public  class Program
    {
        static void Main(string[] args)
        {


            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var item in carManager.GetCarDetailDtos().Data)
            {
                Console.WriteLine(item);
            }


        }
    }
}
