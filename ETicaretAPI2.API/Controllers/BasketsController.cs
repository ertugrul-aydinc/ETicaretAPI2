using ETicaretAPI2.Application.Consts;
using ETicaretAPI2.Application.CustomAttributes;
using ETicaretAPI2.Application.Enums;
using ETicaretAPI2.Application.Features.Commands.Basket.AddItemToBasket;
using ETicaretAPI2.Application.Features.Commands.Basket.RemoveBasketItem;
using ETicaretAPI2.Application.Features.Commands.Basket.UpdateQuantity;
using ETicaretAPI2.Application.Features.Queries.Basket.GetBasketItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class BasketsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Baskets, ActionType = ActionType.Reading, Definition ="Get Basket Items")]
        public async Task<IActionResult> GetBasketItems([FromQuery]GetBasketItemsQueryRequest getBasketItemsQueryRequest)
        {
            List<GetBasketItemsQueryResponse> response = await _mediator.Send(getBasketItemsQueryRequest);
            return Ok(response);
        }


        [HttpPost]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Baskets, ActionType = ActionType.Writing, Definition = "Add Item To Basket")]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest addItemToBasketCommandRequest)
        {
            AddItemToBasketCommandResponse response = await _mediator.Send(addItemToBasketCommandRequest);
            return Ok(response);
        }


        [HttpPut]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Baskets, ActionType = ActionType.Updating, Definition = "Update Quantity")]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
        {
            UpdateQuantityCommandResponse response = await _mediator.Send(updateQuantityCommandRequest);
            return Ok(response);
        }


        [HttpDelete("{BasketItemId}")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Baskets, ActionType = ActionType.Deleting, Definition = "Remove Basket Item")]
        public async Task<IActionResult> RemoveBasketItem([FromRoute]RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
        {
            RemoveBasketItemCommandResponse response = await _mediator.Send(removeBasketItemCommandRequest);
            return Ok(response);
        }
    }
}
