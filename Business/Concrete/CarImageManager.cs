using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public  IResult Add( IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CarImageLimitExceeded(carImage.CarId));
            if (!result.Success)
            {
                return result;
            }
            var upload = CarImageHelper.Upload(file);
            carImage.CreatedDate = DateTime.Now;
            carImage.ImagePath = upload.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new  SuccessResult();
        }

        public IResult DeleteByCarId(int carId)
        {
            var deleteImage = _carImageDal.Get(c => c.CarId == carId);
            _carImageDal.Delete(deleteImage);
            return new SuccessResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == id));
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var ımageDelete = _carImageDal.Get(c => c.CarId == carImage.CarId);
            if (ımageDelete==null)
            {
                return new ErrorResult("bulunamadı");
            }

            var result = CarImageHelper.Update(file, ımageDelete.ImagePath);

            carImage.ImagePath = result.Message;
            _carImageDal.Uptade(carImage);


            return new SuccessResult();
        }

        private IResult CarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId==carId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }

    }
}
