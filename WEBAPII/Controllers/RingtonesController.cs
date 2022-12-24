using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RingtonesController : ControllerBase
    {

        RingtoneService _ringtoneService;

        public RingtonesController(RingtoneService ringtoneService)
        {
            _ringtoneService = ringtoneService;
        }


        [HttpPost("add")]
        public IActionResult add([FromForm(Name ="sound")] IFormFile ringtone,[FromForm]Product product)
        {

            var result=_ringtoneService.add(ringtone, product);
            if (result==null)
            {
                return BadRequest("olmadı");

            }
            return Ok(result);
        }
    }
}
