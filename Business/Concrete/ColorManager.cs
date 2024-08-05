using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run(CheckColorExist(color));

            if(result != null)
            {
                return result;
            }

            _colorDal.Add(color);
            return new SuccessResult("Renk eklendi");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            IResult result = BusinessRules.Run(CheckColorExist(color));

            if (result != null)
            {
                return result;
            }

            _colorDal.Update(color);
            return new SuccessResult("Renk güncellendi");
        }

        public IResult CheckColorExist(Color color)
        {
            var result = _colorDal.GetAll(c => c.Name.ToLower() == color.Name.ToLower()).Any();

            if(result)
            {
                return new ErrorResult(Messages.ColorExist);
            }

            return new SuccessResult();
        }
    }
}
