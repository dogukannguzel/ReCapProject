using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Car car)
        {
            if (CarCheck(car))
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult("error");

           
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(Messages.CarsListed,_carDal.GetCarDetailDto());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll(c => c.BrandId == id)); 
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return   new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Uptade(Car car)
        {
            _carDal.Uptade(car);
            return new SuccessResult(Messages.CarUptaded);
        }




        private bool CarCheck(Car car)
        {
            if (car.Description.Length <= 2 || car.DailyPrice <= 0)
            {
                return false;
            }


            return true;
        }





    }
}
