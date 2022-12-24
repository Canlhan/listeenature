using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface RingtoneService
    {
        IDataResult<List<Ringtone>> getAll();

        IDataResult<Ringtone> get(int productId);
         
        IDataResult<Ringtone> add(IFormFile ringtone,Product product);

    }
}
