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
    public class CardController : ControllerBase
    {

        ICreditCardService _creditCardService;

        public CardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }


        [HttpGet]
        public IActionResult getAll()
        {

            var result = _creditCardService.getCards();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult getCardByUserId(int id)
        {

            var result = _creditCardService.getCardsByUserId(id);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("card/{cardid}")]
        public IActionResult getCardcardnumberId(string  cardid)
        {

            var result = _creditCardService.getCard(cardid);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult addCard(CreditCard creditCard )
        {

            var result = _creditCardService.addCard(creditCard);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
