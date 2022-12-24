﻿using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Core.Utilities.FileHelpers;

namespace Business.Concrete
{
    public class RingtoneManager : RingtoneService
    {

        IRingtoneDal _ringtoneDal;
        IProductService _productService;

        public RingtoneManager(IRingtoneDal ringtoneDal, IProductService productDal)
        {
            _ringtoneDal = ringtoneDal;
            _productService = productDal;
        }

        public IDataResult<Ringtone> add(IFormFile ringtone,Product product)
        {
            var productget = _productService.GetById(product.id);

            if (productget==null)
            {

                return new ErrorDataResult<Ringtone>("product yok");
            }
            Ringtone sound = new Ringtone
            {
                productId = productget.id,
                soundPath = FileHelper.newPath(ringtone),
                createdat = DateTime.Now
            };

            _ringtoneDal.Add(sound);
            return new SuccessDataResult<Ringtone>(sound);

        }

        public IDataResult<Ringtone> get(int productId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Ringtone>> getAll()
        {
            throw new NotImplementedException();
        }
    }
}
