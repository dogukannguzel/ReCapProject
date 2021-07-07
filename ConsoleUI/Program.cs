﻿using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
  public  class Program
    {
        static void Main(string[] args)
        {


            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var item in carManager.getAll())
            {
                Console.WriteLine(item.DailyPrice);
            }


        }
    }
}
