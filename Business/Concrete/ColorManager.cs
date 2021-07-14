using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class ColorManager : ColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(Messages.ColorListed, _colorDal.GetAll());
        }

        public IResult Uptade(Color color)
        {
            _colorDal.Uptade(color);
           return new SuccessResult(Messages.ColorUptaded);
        }

      
    }
}
