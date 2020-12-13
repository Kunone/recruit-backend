using AutoMapper;
using Creditcard.DataContract;
using Creditcard.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creditcard.Api.Controllers
{
    [ApiController]
    [Route("api/credit-cards")]
    [Authorize]
    public class CreditcardController : ApiController
    {
        private readonly ICreditcardService _creditcardService;
        private readonly IMapper _mapper;

        public CreditcardController(ICreditcardService creditcardService, IMapper mapper)
        {
            _creditcardService = creditcardService;
            _mapper = mapper;
        }

        [Route("{cardId}")]
        [HttpGet]
        public async Task<IActionResult> Get(string cardId)
        {
            var userId = GetUserId();
            var card = await _creditcardService.GetCard(userId, cardId);
            var view = _mapper.Map<CardViewModel>(card);
            return Ok(view);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var cards = await _creditcardService.GetAllCards(userId);
            List<CardViewModel> views = new List<CardViewModel>();
            foreach (var card in cards)
            {
                views.Add(_mapper.Map<CardViewModel>(card));
            }
            return Ok(views);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCard([FromBody] CardViewModel cardViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var userId = GetUserId();
            var card = _mapper.Map<Card>(cardViewModel);

            await _creditcardService.SaveCard(userId, card);

            return Ok(true);
        }
    }
}
